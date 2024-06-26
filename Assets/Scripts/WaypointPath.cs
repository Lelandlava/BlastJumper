using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: LeVassar, Leland, help from Ketra Games tutorial
 * Purpose: Controls logic for counting which waypoint we are on and moving to. 
 * Created: 4/28/24
 */

public class WaypointPath : MonoBehaviour
{
    public Transform GetWaypoint (int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }

    public int GetNextWayPointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }
}
