using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputEvents : MonoBehaviour
{
    // Reference to PlayerController for Look Events
    PlayerController controller; 

    PlayerControls playerControls;

    public Vector2 currentMousePos = Vector2.zero;

    public Vector2 lastMousePos = Vector2.zero;

    public Action<Vector2> lookOccured; 


    private void Awake()
    {
        playerControls = new PlayerControls();

        controller = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        lookOccured += controller.Look; 
    }

    // Update is called once per frame
    void Update()
    {
        currentMousePos = playerControls.RegularGame.Look.ReadValue<Vector2>();

        if (!currentMousePos.Equals(lastMousePos)) 
        {
            lookOccured?.Invoke(currentMousePos);
        }
    }
}
