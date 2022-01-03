using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	
	public Waypoint previousWaypoint;
	public Waypoint nextWaypoint;
	
	[Range(0f,5f)]
	public float width = 2f;

	public List<Waypoint> branches;

	public bool isTrafficLight ;

	public bool isStopSign;

	// r is red
	//y is yellow
	//g is green
	public char trafficLightStatus = 'g';
	
	
[Range(0f,1f)]
public float branchRatio = 0.5f;

	//returns position of waypoint
	public Vector3 GetPosition()
	{
		Vector3 minBound = transform.position + transform.right * width / 2f;
		Vector3 maxBound = transform.position - transform.right * width /2f;
		
		return Vector3.Lerp(minBound,maxBound,Random.Range(0f,1f));
		
	}
	
}
