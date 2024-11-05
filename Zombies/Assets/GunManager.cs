using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    // Current Gun Equipped by the player
    public GameObject currentGun;

    public List<GameObject> equippedGuns = new List<GameObject>();

    public Dictionary<int, GameObject> possibleGuns = new Dictionary<int, GameObject> ();

    // Manages the tilt of the gun and the current gunstate
    private GunTilt currentGunTiltManager;

    private GunState currentGunState;

    private Dictionary<GunState.State, GunState> gunStates = new Dictionary<GunState.State, GunState>();

    // Represent the aim down sights and hip fire of a character
    public GameObject ADS;

    public GameObject HipFireObj;

    public float GunAdsSpeed = 5; 

    [SerializeField] private bool isAimingDownSight = false;

    // Considers if the player is moving
    private bool isMoving = false;

    private bool isSprinting = false; 

    // Gun Bobbing 
    public float amplitude = 0.01f;

    public float frequency = 2; 

    // Start is called before the first frame update
    void Start()
    {
        currentGunTiltManager = currentGun.GetComponent<GunTilt>();

        CreateGunStates(); 

        currentGunState = gunStates[GunState.State.hipFire]; 
    }

    public void CreateGunStates()
    {
        for (int i = 0; i < Enum.GetValues(typeof(GunState.State)).Length; i++)
        {
            switch (i)
            {
                case 0:
                    gunStates.Add(GunState.State.hipFire, new HipFire(currentGun.transform, HipFireObj.transform, GunAdsSpeed, this, currentGunTiltManager, frequency, amplitude));
                    break;
                case 1:
                    gunStates.Add(GunState.State.ads, new Ads(currentGun.transform, ADS.transform, GunAdsSpeed, this));
                    break;

            }

        }

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

    public void SetIsMoving(bool move)
    {
        isMoving = move; 
    }

    public bool GetIsSprinting()
    {
        return isSprinting;     
    }

    public void SetIsSprinting(bool isSprinting)
    {
        this.isSprinting = isSprinting;
    }

    public bool GetIsMoving()
    {
        return isMoving; 
    }

    // Switches between aiming down sights and hipfiring
    public void ManageGunState()
    {
        currentGunState.OnStateUpdate();

        if (isAimingDownSight && currentGunState.state == GunState.State.hipFire)
        {
            currentGunState.OnStateExit();

            currentGunState = gunStates[GunState.State.ads];

            currentGunState.OnStateEnter();
        }
        else if (!isAimingDownSight && currentGunState.state == GunState.State.ads)
        {
            currentGunState.OnStateExit();

            currentGunState = gunStates[GunState.State.hipFire];

            currentGunState.OnStateEnter();
        }
    }

    // Reads the current movement context of the player
    public void ReadCurrentCharacterContext(PlayerController.moveDirInfo moveDir)
    {
        currentGunState.ReadCurrentCharacterContext(moveDir);
    }
}
