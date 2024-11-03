using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Mouse Position
    Vector2 currentMousePosition = Vector2.zero;

    public float xSensitivity = 5;

    public float ySensitivity = 5;

    public float speed = 5;

    // Jumping Variables

    public bool isGrounded = true;

    public Transform characterFeet = null; 

    public bool isFalling = false;

    public float upwardVelocity = 0;

    public float jumpForce = 5;


    // Modelling gravity

    private const float gravityUp = 4.9f;

    private const float gravityDown = 9.8f; 

    


    // Camera
    Camera mainPlayerCamera;

    // Camera Transform 
    Transform cameraTransform; 

    private void Start()
    {
        mainPlayerCamera = Camera.main; 

        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;

        // Get Child Transform - Todo, rework later
        characterFeet = GameObject.FindGameObjectWithTag("CharacterFeet").transform; 
    }

    public void Update()
    {
        UpdateJump(); 


    }

    public void Look(Vector2 mousePosition)
    {
        mousePosition.x *= xSensitivity * Time.deltaTime; 

        mousePosition.y *= ySensitivity * Time.deltaTime; 

        currentMousePosition += mousePosition;

        // Rotate Camera

        float y = -currentMousePosition.y;

        y = Mathf.Clamp(y, -85, 85);

        // Rotate Body

        float x = currentMousePosition.x;

        transform.rotation = Quaternion.Euler(0, x, 0);

        cameraTransform.rotation = Quaternion.Euler(y, x, 0); 

    }

    public void Move(Vector2 info)
    {
        info.Normalize();

        this.transform.position += this.transform.forward * speed * Time.deltaTime * info.y;
        this.transform.position += this.transform.right * speed * Time.deltaTime * info.x; 

        cameraTransform.position = transform.position;
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

        if (!isGrounded)
        {
            isGrounded = IsGrounded();
        }

        if (isGrounded)
        {
            isFalling = false;

            upwardVelocity = 0; 
        }

    }

    bool IsGrounded()
    {
        RaycastHit hit; 

        return Physics.SphereCast(characterFeet.position, 0.1f, -Vector3.up, out hit, 0.05f);
    }
}
