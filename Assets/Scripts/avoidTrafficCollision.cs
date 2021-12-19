using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avoidTrafficCollision : MonoBehaviour{
GameObject[] spawned_traffic;

   
 public string txt = "Hello World";

 public Rect rect;
   
       void Start() {
         spawned_traffic = GameObject.FindGameObjectsWithTag("traffic");
    }
    void Update()  {
        foreach(GameObject to in spawned_traffic)        {

            if (this.transform.position == to.transform.position)
            {
                //skip
            }
            else
            {
                if ( this.transform.rotation.y == to.transform.rotation.y)
                {

                }
                float dist = Vector3.Distance(to.transform.position, transform.position);
                     if (dist < 30) {
                this.GetComponent<Traffic>().movementSpeed = 0;
            }
            else {
                this.GetComponent<Traffic>().movementSpeed = 10;
            }
            }

        }
    }
}
