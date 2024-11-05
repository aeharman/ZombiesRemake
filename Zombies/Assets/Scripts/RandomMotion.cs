using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMotion : MonoBehaviour
{
    public float sway = 0.1f;

    public float frequency = 1;

    public float xOffset = 0;

    public float yOffset = 0;

    public float zOffset = 0;

    public float smooth = 5; 

    public Vector3 offset = Vector3.zero;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        offset.x = xOffset; 
        offset.y = yOffset;
        offset.z = zOffset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
