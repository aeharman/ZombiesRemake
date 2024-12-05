using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bee;

    public GameObject player; 

    float time = 5; 

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
            var o = Instantiate(bee);

            o.transform.position = this.transform.position;

            var e = o.GetComponent<Enemy>();

            e.playerObj = player;

            yield return new WaitForSeconds(time);
        }

    }
}
