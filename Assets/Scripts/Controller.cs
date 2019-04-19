using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody bullet;
    public float Speed { get; set; }

    public float speedVar;
    
    public GameObject controller;
    public GameObject tip;


    // Start is called before the first frame update
    void Start()
    {
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
        {
            Debug.Log("controller detected");
        }
        Speed = speedVar;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, tip.transform.position, controller.transform.rotation);
            bulletClone.velocity = controller.transform.forward * Speed;
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            bulletClone.GetComponent<Renderer>().material.color = newColor;
        }

        if (Physics.Raycast(controller.transform.position, transform.forward, out hit))
        {
            if(hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "ColorCube") // to make this more versatile, tag all the ColorCubes and then change this line to check for tag
                {
                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        hit.collider.gameObject.SendMessage("ChangeColor"); // and change this line to send message to hit.collider.gameObject, so only that cube changes color
                        Debug.Log("trigger pulled");
                    }
                }
            }
        }
    }
}
