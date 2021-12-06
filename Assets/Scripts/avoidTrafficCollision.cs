using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avoidTrafficCollision : MonoBehaviour
{

    //private SpawnTraffic traffic_objects;
GameObject[] spawned_traffic;

    void Start()
    {
         spawned_traffic = GameObject.FindGameObjectsWithTag("traffic");

    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject to in spawned_traffic)
        {
            float dist = Vector3.Distance(to.transform.position, transform.position);

           // Debug.Log(dist);


            if (dist < 20)
            {
                GetComponent<Traffic>().movementSpeed = 0;
            }
            else 
            {
                GetComponent<Traffic>().movementSpeed = 10;
            }
        }

    }
}
