using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    automatic, 
    semi, 
    revolver, 
    rifle
}

public class Gun : MonoBehaviour
{
    // TODO Make a process to set audio manager and gun manager for all guns
    public AudioManager audioManager;

    private Animator animator; 

    [Header("Ammo Information")]
    public int clipSize;
    public int currentAmmo;

    [Header("Gun Information")]
    public GunType type;
    public float damage;
    public float fireRate;

    [Header("ADS and Hip Zones")]
    public Vector3 ads = Vector3.zero;
    public Vector3 hip = Vector3.zero;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Ammo", currentAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        --currentAmmo;
        animator.SetInteger("Ammo", currentAmmo); 
        if (currentAmmo > 0)
        {
            audioManager.PlayAudioClip();
        }
    }
}
