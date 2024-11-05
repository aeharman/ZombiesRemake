using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject currentGun;

    public List<GameObject> equippedGuns = new List<GameObject>();

    public Dictionary<int, GameObject> possibleGuns = new Dictionary<int, GameObject> ();

    private GunTilt currentGunTiltManager;

    private GunState currentGunState;

    public GameObject ADS;

    public GameObject HipFireObj;

    public float GunAdsSpeed = 5; 

    [SerializeField] private bool isAimingDownSight = false; 

    // Start is called before the first frame update
    void Start()
    {
        currentGunTiltManager = currentGun.GetComponent<GunTilt>();

        currentGunState = new HipFire(currentGun.transform, HipFireObj.transform, GunAdsSpeed); 
        currentGunState.SetGunTilt(currentGunTiltManager);
    }

    // Update is called once per frame
    void Update()
    {
        ManageGunState(); 
    }

    // Determines if the player is currently aiming down sights
    public void SetIsADS(bool isADS)
    {
        isAimingDownSight = isADS; 
    }

    // Switches between aiming down sights and hipfiring
    public void ManageGunState()
    {
        currentGunState.OnStateUpdate();

        if (isAimingDownSight && currentGunState.state == GunState.State.hipFire)
        {
            currentGunState.OnStateExit();

            currentGunState = new Ads(currentGun.transform, ADS.transform, GunAdsSpeed);

            currentGunState.OnStateEnter();
        }
        else if (!isAimingDownSight && currentGunState.state == GunState.State.ads)
        {
            currentGunState.OnStateExit();

            currentGunState = new HipFire(currentGun.transform, HipFireObj.transform, GunAdsSpeed);
            currentGunState.SetGunTilt(currentGunTiltManager);

            currentGunState.OnStateEnter();
        }
    }

    // Reads the current movement context of the player
    public void ReadCurrentCharacterContext(PlayerController.moveDirInfo moveDir)
    {
        currentGunState.ReadCurrentCharacterContext(moveDir);
    }
}
