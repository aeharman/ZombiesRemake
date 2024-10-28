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


    // Camera
    Camera mainPlayerCamera;

    // Camera Transform 
    Transform cameraTransform; 

    private void Start()
    {
        mainPlayerCamera = Camera.main; 

        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
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
}
