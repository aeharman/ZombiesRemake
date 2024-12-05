using System;
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

    public Action reloadFinished; 

    [Header("Ammo Information")]
    public int clipSize;
    public int currentAmmo;

    [Header("Gun Information")]
    public GunType type;
    public int damage = 1;
    public float fireRate;
    // TODO GET programatically
    public GameObject gunSpout; 

    [Header("ADS and Hip Zones")]
    public Vector3 ads = Vector3.zero;
    public Vector3 hip = Vector3.zero;

    // Hits container
    [Header("Objects Hit")]
    public List<RaycastHit> hits = new List<RaycastHit>();

    // Player Possession
    [Header("Player Information")]
    public bool doesPlayerPossess = false;
    public bool isCurrentGun = false; 

    

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
        audioManager.PlayAudioClip();
        RayCastShoot(); 
    }

    public void ReloadFinished()
    {
        currentAmmo = clipSize;

        animator.SetInteger("Ammo", clipSize); 

        reloadFinished?.Invoke();
    }

    // TODO weaken damage overtime
    public void RayCastShoot()
    {
        Ray ray = new Ray(gunSpout.transform.position, -gunSpout.transform.forward);

        hits.AddRange(Physics.RaycastAll(ray, 300));

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy e))
            {
                e.TakeDamage(damage); 
            }
        }

        hits.Clear(); 


    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(gunSpout.transform.position, -gunSpout.transform.forward);

        Gizmos.DrawRay(ray);
    }
}
