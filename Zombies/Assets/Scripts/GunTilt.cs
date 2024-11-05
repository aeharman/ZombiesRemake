using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTilt : MonoBehaviour
{
    public PlayerController.moveDirInfo moveDir; 

    public float zTilt = 15;

    public float speed = 5; 
    // Start is called before the first frame update
    void Start()
    {
        moveDir = PlayerController.moveDirInfo.stationary; 
    }

    // Update is called once per frame
    void Update()
    {
        var vec = new Vector3(0, 0, zTilt);

        float currentAngle = transform.rotation.eulerAngles.z;
        float ang = Mathf.MoveTowardsAngle(currentAngle, zTilt, Time.deltaTime * speed);
        transform.localRotation = Quaternion.Euler(0, 0, ang);
    }

    public void Tilt(PlayerController.moveDirInfo info)
    {
        moveDir = info; 

        if (moveDir == PlayerController.moveDirInfo.left)
        {
            zTilt = -15; 
        }
        else if (moveDir == PlayerController.moveDirInfo.right)
        {
            zTilt = 15; 
        }
        else
        {
            zTilt = 0; 
        }
         
    }
}
