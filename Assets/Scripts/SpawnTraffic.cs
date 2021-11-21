using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Linq;

public class SpawnTraffic : MonoBehaviour
{
	//list to keep track of traffic vehicles
	public List<GameObject> traffic = new List<GameObject>();

	
	private int num_traffic;
	
	//list to keep track of spawn points
	//public List<Transform> WP = new List<Transform>();
	
	public List<GameObject> spawned_traffic = new List<GameObject>( new GameObject[100]);

	//keep traffic of number of spawn points
	public int num_spawn ;
	
	private int rndTraffic;
	
	public int num_spawned = 0;
	
	
	public int currentSpawnIndex;
	
		public Traffic tfc;
	
	//number of waypoints
	public int num_wps;


	//waypoint name used for testing for spawn points
	public string wp_name;


    // Start is called before the first frame update
    void Start()
    {
		//number of traffic vehicles
		 num_traffic = traffic.Count;

		//total number of waypoints
		num_wps = transform.childCount;
		 
		spawnTraffic(num_wps);
			
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	void spawnTraffic(int num_wps)
	{
	
			//iterate through all of our spawn points and spawn random vehicles
		for (int i = 0; i<num_wps; i++)
		{
			wp_name = transform.GetChild(i).name;
			//if waypoint is a valid spawn point
			if ( wp_name.Contains("SP"))

			{	
				//set the variable for keeping track of our spawn index
				currentSpawnIndex = i ;			
					
			//randomly select a traffic vehicle
			rndTraffic = Random.Range(0, num_traffic);

			//get our spawn point position
			Vector3 spawnpos = transform.GetChild(i).transform.position;	

			Quaternion spawndir = transform.GetChild(i).transform.rotation;
			
			//create a duplicate object of traffic
			spawned_traffic[num_spawned] = GameObject.Instantiate(traffic[rndTraffic]);

						//set its position to our spawn point
			spawned_traffic[num_spawned].transform.position = spawnpos;
			spawned_traffic[num_spawned].transform.rotation = spawndir;
			
			Debug.Log(transform.GetChild(i));
			Debug.Log(transform.GetChild(i).GetComponent<Waypoint>());

			//set its waypoints
			spawned_traffic[num_spawned].GetComponent<WaypointNavigator>().currentWaypoint = transform.GetChild(i).GetComponent<Waypoint>();
	
			//show the traffic vehicle
			spawned_traffic[num_spawned].SetActive(true);
		
			//increment number of spawnned vewhicles
			num_spawned = num_spawned + 1;
			
			//Debug.Log("iterator: " + rndTraffic);
			}

		}
	
	
	}
	

}
