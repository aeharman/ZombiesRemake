using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Mouse Position
    [Header("Mouse Information")]
    Vector2 currentMousePosition = Vector2.zero;

    public float xSensitivity = 5;

    public float ySensitivity = 5;

    public float speed = 5;

    // Jumping Variables
    [Header("Jumping Information")]
    public bool isGrounded = true;

    public Transform characterFeet = null; 

    public bool isFalling = false;

    public float upwardVelocity = 0;

    public float jumpForce = 5;


    // Modelling gravity
    private const float gravityUp = 4.9f;

    private const float gravityDown = 9.8f; 

    // Camera and Camera Transform 
    Transform cameraTransform;

    // Action Event for if the current player is moving
    Action<bool> checkMoveEvent;

    bool isMoving = false; 

    // Gun Controller 
    public GunManager gunManager;

    public Action<moveDirInfo> moveDirContext;

    // Boolean for Aiming and Action for aiming event
    [Header("Aiming Information")]
    [SerializeField] bool isAds = false;

    public Action<bool> aimingEvent;

    // Firing Event
    [Header("Firing Information")]
    [SerializeField] bool isFiring = false; 

    public Action<bool> holdFiringEvent;
    public Action tapFire; 

    // Sprint information
    [Header("Sprinting Information")]
    [SerializeField] bool isSprinting = false;
    [SerializeField] float speedModifier = 1.25f;
    float sprintTimer = 4f;
    [SerializeField] float sprintTimerMaxValue = 4f;
    float stamRegenTimer = 1f;
    [SerializeField] float stamRegenTimerMaxValue = 1f; 

    public Action<bool> sprintingEvent;

    // Reloading Information
    [Header("Reloading Information")]

    public bool isReloading = false;
    public Action reloadingEvent; 



    public enum moveDirInfo
    {
        forward = 0, 
        back = 1, 
        right = 2, 
        left = 3, 
        stationary = 4
    }

    moveDirInfo moveDir = moveDirInfo.stationary; 


    private void Start()
    {
        // Gun Manager Dependency
        moveDirContext += gunManager.ReadCurrentCharacterContext;
        aimingEvent += gunManager.SetIsADS;
        checkMoveEvent += gunManager.SetIsMoving;
        sprintingEvent += gunManager.SetIsSprinting;
        holdFiringEvent += gunManager.SustainedFiringGun;
        tapFire += gunManager.TapFireGun;
        reloadingEvent += gunManager.ReloadGun;
        gunManager.currentGunScript.reloadFinished += ReloadFinished; 

        cameraTransform = GameObject.FindGameObjectWithTag("CameraHolder").transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        UpdateJump();
    }

    public void Look(Vector2 mousePosition)
    {
        if (isAds)
        {

            mousePosition.x *= (xSensitivity / 2) * Time.deltaTime;

            mousePosition.y *= (ySensitivity / 2) * Time.deltaTime;

            currentMousePosition += mousePosition;
        }
        else
        {
            mousePosition.x *= xSensitivity * Time.deltaTime;

            mousePosition.y *= ySensitivity * Time.deltaTime;

            currentMousePosition += mousePosition;
        }

        // Rotate Camera and clamp rotation 

        float y = -currentMousePosition.y;

        y = Mathf.Clamp(y, -85, 85);

        // Rotate Body

        float x = currentMousePosition.x;

        transform.rotation = Quaternion.Euler(0, x, 0);

        cameraTransform.rotation = Quaternion.Euler(-y, x, 0);

    }

    public void ProcessAim(float aim)
    {
        if (aim > 0)
        {
            isAds = true; 
        }
        else
        {
            isAds = false;
        }

        aimingEvent?.Invoke(isAds); 
    }    

    public void MoveAnimationInfo(Vector2 info)
    {
        if (info.x > 0)
        {
            moveDir = moveDirInfo.right; 
        }
        else if (info.x < 0)
        {
            moveDir = moveDirInfo.left; 
        }
        else
        {
            moveDir = moveDirInfo.stationary; 
        }

        moveDirContext?.Invoke(moveDir);
    }

    public void Move(Vector2 info)
    {
        info.Normalize();

        if(!isAds)
        {
            var speedModified = speed;

            if (isSprinting && isGrounded)
            {
                speedModified *= speedModifier;
            }

            this.transform.position += -this.transform.forward * speedModified * Time.deltaTime * info.y;
            this.transform.position += -this.transform.right * speedModified * Time.deltaTime * info.x;


            var vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            cameraTransform.position = vec;
        }
        else
        {

            this.transform.position += -this.transform.forward * (speed / 2) * Time.deltaTime * info.y;
            this.transform.position += -this.transform.right * (speed / 2) * Time.deltaTime * info.x;


            var vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            cameraTransform.position = vec;
        }

        if (info.Equals(Vector2.zero)) isMoving = false;
        else isMoving = true;

        checkMoveEvent?.Invoke(isMoving); 
    }

    public void Jump()
    {
        if (!isGrounded)
        {
            return; 
        }
        else
        {
            upwardVelocity = 1 * jumpForce;

            isGrounded = false; 
        }
    }

    public void UpdateJump()
    {

        transform.position += new Vector3(0, upwardVelocity * Time.deltaTime, 0);

        if (!isGrounded && !isFalling)
        {
            upwardVelocity -= gravityUp * Time.deltaTime;
        }
        else if (!isGrounded)
        {
            upwardVelocity -= gravityDown * Time.deltaTime;
        }

        if (upwardVelocity < 0 && !isFalling)
        {
            isFalling = true;
        }

        isGrounded = IsGrounded();

        if (isGrounded)
        {
            isFalling = false;

            upwardVelocity = 0; 
        }

    }

    public void Sprint(float sprint)
    {
        if (sprint > 0 && !isAds && isMoving && !isFiring && !isReloading)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false; 
        }

        sprintingEvent?.Invoke(isSprinting); 
    }

    // Todo Send Shooting information to the gun
    public void ProcessFire(int context)
    {
        // Shake the camera
        if (context == 1)
        {
            isFiring = true; 
        }
        else
        {
            isFiring = false; 
        }

        holdFiringEvent?.Invoke(isFiring);
    }

    // TODO Send Shooting information to the gun
    public void FireClicked(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {

            tapFire?.Invoke();

            isReloading = false; 
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && !isReloading)
        {
            isReloading = true;

            reloadingEvent?.Invoke(); 
        }
    }

    public void ReloadFinished()
    {
        isReloading = false; 
    }

    bool IsGrounded()
    {
        RaycastHit hit; 

        return Physics.SphereCast(characterFeet.position, 0.1f, -Vector3.up, out hit, 0.05f);
    }
}
