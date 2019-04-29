using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMove : MonoBehaviour {

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
	private void Start () {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {

        // Move Enemy
        Move();
	}

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
			
			
			Vector3 dir = waypoints[waypointIndex].position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			// transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			
			
			
			var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, angle);
			transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
 
			
			// Vector3 newDir = Vector3.RotateTowards(transform.forward, (waypoints[waypointIndex].position - transform.position), (moveSpeed * Time.deltaTime), 0.0f);
			// transform.rotation = Quaternion.AngleAxis(newDir, Vector3.forward);
		
	

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
		if (waypointIndex == waypoints.Length - 1) {
			waypointIndex = 0;
		}
    }
}