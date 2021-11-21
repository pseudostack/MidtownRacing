using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    Traffic controller;

    public Waypoint currentWaypoint;

    private void Awake()
    {
        Debug.Log("Awaken...");
        controller = GetComponent<Traffic>();
    }


    void Start()
    {
        Debug.Log("setting Destination...");
        controller.SetDestination(currentWaypoint.GetPosition());

        Debug.Log("destination here is: " + currentWaypoint.GetPosition());
    }

    void Update()
    {
        if (controller.reachedDestination)
        {

            bool shouldBranch = false;

            if (currentWaypoint.branches != null && currentWaypoint.branches.Count >0)
            {
                shouldBranch = Random.Range(0f,1f) <= currentWaypoint.branchRatio ? true : false;
            }

            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }
            else
            {
             currentWaypoint = currentWaypoint.nextWaypoint;   
            }

            //Debug.Log("current waypoint: " + currentWaypoint);
            currentWaypoint = currentWaypoint.nextWaypoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }

    }

}
