using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Mouse Position
    Vector2 currentMousePosition = Vector2.zero;

    public float xSensitivity = 5;

    public float ySensitivity = 100;


    // Camera
    Camera mainPlayerCamera;

    private void Start()
    {
        mainPlayerCamera = Camera.main; 

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Look(Vector2 mousePosition)
    {
        currentMousePosition = mousePosition;

        Transform transform = mainPlayerCamera.transform;

        float y = -currentMousePosition.y * ySensitivity * Time.deltaTime;

        transform.Rotate(y, 0, 0);

        Debug.Log(transform.rotation.eulerAngles); 

        if (transform.rotation.eulerAngles.x > 270)
        {
            transform.rotation = Quaternion.Euler(-85, 0, 0); 
        }

    }
}
