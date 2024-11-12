using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads : GunState
{
    public Transform gunPosition;

    public Transform AdsPosition; 

    // Intializes the gunState
    public Ads(Transform gunPos, Transform AdsPos, float swivel, GunManager manager) : base(manager)
    {
        gunPosition = gunPos;
        AdsPosition = AdsPos;

        state = State.ads;

        this.swivelSpeed = swivel;
    }

    // Updates the gun to be "aimed in"
    public override void OnStateUpdate()
    {
        if (Vector3.Distance(gunPosition.localPosition, AdsPosition.localPosition) > 0.0005f)
        {
            gunPosition.localPosition = Vector3.Lerp(gunPosition.localPosition, AdsPosition.localPosition, Time.deltaTime * swivelSpeed);
        }
        else if (!gunPosition.localPosition.Equals(AdsPosition.localPosition)) 
        {
            gunPosition.localPosition = AdsPosition.localPosition;
        }
    }
}
