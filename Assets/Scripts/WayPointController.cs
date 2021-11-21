using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
	
	public List<Transform> waypoints = new List<Transform>();
	private Transform targetWaypoint;
	private int targetWaypointIndex = 0;
	
	// to know if car is close to the waypoint
	private float minDistance = 0.1f;
	
	//
	private float lastWayPointIndex;
	
	
	private float movementSpeed = 13.0f;
	
	private float rotationSpeed = 2.0f;
	
    // Start is called before the first frame update
    void Start()
    {
		lastWayPointIndex = waypoints.Count -1;
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
		float movementStep = movementSpeed * Time.deltaTime;
		float rotationStep = rotationSpeed * Time.deltaTime;
		
		Vector3 directionToTarget = targetWaypoint.position - transform.position;
		Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
		
		transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
		
		float distance = Vector3.Distance(transform.position, targetWaypoint.position);
				checkDistanceToWayPoint(distance);
				
		transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
        

		
   }
	
	void checkDistanceToWayPoint(float currentDistance)
	{
		if(currentDistance <= minDistance)
		{
			targetWaypointIndex++;
			UpdateTargetWaypoint();
		
		}
		
	
	}
	
	
	void UpdateTargetWaypoint()
	
	{
		if(targetWaypointIndex > lastWayPointIndex)
		{
			targetWaypointIndex = 0;
		}
		
		targetWaypoint = waypoints[targetWaypointIndex];
	}
	
	
	
}
