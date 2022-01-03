using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    Traffic controller;

    public Waypoint currentWaypoint;

    private void Awake()
    {
        controller = GetComponent<Traffic>();
    }


    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    void Update()
    {
        if (controller.reachedDestination)
        {

            if (currentWaypoint.trafficLightStatus == 'r')
            {
                controller.movementSpeed = 0;
            }

            else
            {
                controller.movementSpeed = 10;
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
            currentWaypoint = currentWaypoint.nextWaypoint;
            controller.SetDestination(currentWaypoint.GetPosition());
                }
        }

    }

}
