using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunState 
{
    public enum State
    {
        hipFire = 0, 
        ads = 1
    }

    public State state; 

    protected GunTilt gunTilt = null;

    protected float swivelSpeed;

    protected GunManager gunManger = null; 


    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {
    }

    public virtual void OnStateUpdate()
    {

    }

    public GunState(GunManager manager)
    {
        gunManger = manager; 
    }


    public virtual void ReadCurrentCharacterContext(PlayerController.moveDirInfo moveDir)
    {
        
    }

    public void SetGunTilt(GunTilt tilt) 
    {
        gunTilt = tilt; 
    }
}
