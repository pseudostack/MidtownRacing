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

            if (this.transform.position == transform.position)
            {
                //skip
            }
            else
            {
                float dist = Vector3.Distance(to.transform.position, transform.position);
                     if (dist < 30) {
                this.GetComponent<Traffic>().movementSpeed = 0;
            }
            else {
                this.GetComponent<Traffic>().movementSpeed = 10;
            }
            }

               // Debug.Log(this);
               // Debug.Log(to);
               // Debug.Log("-----");
               // Debug.Log("Transform Position: " + transform.position + " Traffic position: " + to.transform.position + " Distance: " + dist);

       
        }
    }
}
