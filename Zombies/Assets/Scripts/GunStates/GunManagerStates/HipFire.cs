using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFire : GunState
{
    public Transform hipFire; 

    public Transform currentPos;

    private Vector3 bobVector;

    private float originalY = 0;

    private float originalX = 0; 

    private float frequency = 0;

    private float amplitude = 0; 
 

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
        else if (gunManger.GetIsMoving() && !gunManger.GetIsSprinting())
        {
            bobVector.y += Mathf.Sin(Time.time * frequency) * amplitude;

            bobVector.x += Mathf.Cos((Time.time * frequency) / 2) * amplitude; 

            hipFire.localPosition = bobVector; 
        }
        else if (gunManger.GetIsMoving())
        {
            bobVector.y += Mathf.Sin(Time.time * frequency * 3) * amplitude;

            bobVector.x += Mathf.Cos((Time.time * frequency * 3) / 2) * amplitude;

            hipFire.localPosition = bobVector;
        }
        else
        {
            bobVector.y = originalY; 

            bobVector.x = originalX;

            hipFire.localPosition = new Vector3(hipFire.localPosition.x, originalY, hipFire.localPosition.z);
        }
    }

    public override void OnStateExit()
    {
        gunTilt.Tilt(PlayerController.moveDirInfo.stationary);

        bobVector.y = originalY;

        bobVector.x = originalX;
    }

    public override void ReadCurrentCharacterContext(PlayerController.moveDirInfo moveDir)
    {
        gunTilt.Tilt(moveDir); 
    }

    public HipFire(Transform gunPos, Transform hipfire, float swivel, GunManager manager, GunTilt tilt, float frequency, float amplitude) : base(manager)
    {
        state = State.hipFire;

        this.hipFire = hipfire;
        this.currentPos = gunPos;

        this.swivelSpeed = swivel;

        gunTilt = tilt;

        originalY = hipfire.localPosition.y;

        originalX = hipfire.localPosition.x; 

        bobVector = new Vector3(hipfire.localPosition.x, hipFire.localPosition.y, hipFire.localPosition.z);

        this.frequency = frequency;

        this.amplitude = amplitude; 
    }

    public float GetAmplitude()
    {
        return amplitude; 
    }

    public void SetAmplitude(float amplitude)
    {
        this.amplitude = amplitude;
    }

    public void SetFrequency(float frequency) 
    {
        this.frequency = frequency; 
    }

    public float GetFrequency()
    {
        return frequency; 
    }

    
}
