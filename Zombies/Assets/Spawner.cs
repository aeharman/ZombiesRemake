using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bee; // The bee prefab
    public GameObject player; // The player object
    float time = 5; // Time interval between spawns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBee()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBee()
    {
        while (true)
        {
            // Instantiate the bee prefab
            var o = Instantiate(bee);

            // Set the position of the spawned bee
            o.transform.position = this.transform.position;

            // Set the tag of the spawned bee to "beeEnemy"
            o.tag = "beeEnemy";

            // Get the Collider component and ensure it's set to "Is Trigger"
            Collider beeCollider = o.GetComponent<Collider>();
            if (beeCollider != null)
            {
                beeCollider.isTrigger = true;  // Set Is Trigger to true
            }

            // Get the Enemy component and assign the player object
            var e = o.GetComponent<Enemy>();
            e.playerObj = player;

            // Wait for the specified time before spawning the next bee
            yield return new WaitForSeconds(time);
        }
    }
}


