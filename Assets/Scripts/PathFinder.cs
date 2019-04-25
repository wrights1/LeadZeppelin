using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public GameObject[] target;
    public float speed;
    private int current = 0;
    private float mpradius = 5;

    void Update()
    {
        
        if (Vector3.Distance(target[current].transform.position, transform.position) < mpradius)
        {
            current++;
            if (current >= target.Length)
            {
                current = 0;
            }

            //var looking = new GameObject().transform;
            //looking.position = transform.position;
            //looking.LookAt(target[current].transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(looking.rotation.x, looking.rotation.y, looking.rotation.z), Time.deltaTime * speed);
            
        }
        
        //transform.Rotate(0,0,0); //fix roation issues
        transform.LookAt(target[current].transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target[current].transform.position, speed * Time.deltaTime);
        
    }
}
