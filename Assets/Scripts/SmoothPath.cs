using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothPath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    public float damping = 10;


    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
        transform.rotation = waypoints[waypointIndex].transform.rotation;

    }

    // Update is called once per frame
    private void Update()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {

            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, waypoints[waypointIndex].rotation, Time.deltaTime * damping);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            waypointIndex = 0;
        }
    }
}
