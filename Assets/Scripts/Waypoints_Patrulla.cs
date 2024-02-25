using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints_Patrulla : MonoBehaviour
{
    public Transform[] waypoints;

    int w_CurrentWaypointIndex;

    public float w_MoveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrulla();
    }

    void Patrulla()
    {
        if (waypoints.Length == 0)
            return;

        Transform currentWaypoint = waypoints[w_CurrentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, w_MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            w_CurrentWaypointIndex = (w_CurrentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
