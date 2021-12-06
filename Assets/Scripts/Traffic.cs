using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traffic : MonoBehaviour
{
	private Transform targetWaypoint;

	
	public bool reachedDestination = false;
		

//for mnovementspeed and rotation speed of traffic vehicles
	[Range(0, 100)]
	public int  movementSpeed ;

	[Range(0,10)]
	public int rotationSpeed ;

	//destintiation will be passed in by Waypoint Navigoator on start()
	public Vector3 destination;
	public int stopDistance;
	public Vector3 destinationDirection;
	public float velocity;
	
    // Start is called before the first frame update
    void Start()
    {
movementSpeed = 10;
rotationSpeed = 120;
stopDistance = 1;

    }

    // Update is called once per frame
    void Update()
    {



		if(transform.position != destination)
		{
			Vector3 destinationDirection = destination - transform.position;
					destinationDirection.y = 0;

			float destinationDistance = destinationDirection.magnitude;
			
			if(destinationDistance >= stopDistance)
			{
				reachedDestination = false;
				Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
				transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
			}
			
			else{
				reachedDestination = true;
			}
		}
    }
	

	public void SetDestination(Vector3 destination)
	{
			this.destination = destination;
			reachedDestination = false;
	}
}
