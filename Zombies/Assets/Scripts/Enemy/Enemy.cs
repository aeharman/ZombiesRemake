using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Health Information")]
    public int maxHealth = 1; 
    public int health = 1;

    [Header("Collider Information")]
    public Collider collider;

    [Header("Player Information")]
    public GameObject playerObj; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerObj != null)
        {
            this.transform.LookAt(playerObj.transform.position);
        }

        this.transform.position += this.transform.forward * Time.deltaTime * 3; 
        

        if (Vector3.Distance(transform.position, playerObj.transform.position) < 0.05)
        {
             
        }
    }

    // TODO Buffer destroy with animation for death and remove collider
    public void TakeDamage(int damage)
    {
        health -= damage; 

        if (health < 1)
        {
            // Todo Play Dying Animation, then destroy
           
            Destroy(this.gameObject); 
        }
    }
}
