using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFire : GunState
{
    public Transform hipFire; 

    public Transform currentPos; 

 

    public override void OnStateEnter()
    {

    }

    public override void OnStateUpdate()
    {

        if (Vector3.Distance(currentPos.localPosition, hipFire.localPosition) > 0.0005f)
        {
            currentPos.localPosition = Vector3.Lerp(currentPos.localPosition, hipFire.localPosition, Time.deltaTime * swivelSpeed);
        }
        else if (!currentPos.localPosition.Equals(hipFire.localPosition)) 
        {
            currentPos.localPosition = hipFire.localPosition;
        }
    }

    public override void OnStateExit()
    {
        gunTilt.Tilt(PlayerController.moveDirInfo.stationary);
    }

    public override void ReadCurrentCharacterContext(PlayerController.moveDirInfo moveDir)
    {
        gunTilt.Tilt(moveDir); 
    }

    public HipFire(Transform gunPos, Transform hipfire, float swivel)
    {
        state = State.hipFire;

        this.hipFire = hipfire;
        this.currentPos = gunPos;

        this.swivelSpeed = swivel; 
    }
}
