using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneParticles : MonoBehaviour
{
    public Component[] particles;
    public int maxShots; // number of times plane must be shot before going down

    void Start()
    {
        particles = gameObject.GetComponentsInChildren<ParticleSystem>(true);
        //foreach (ParticleSystem part in particles)
        //{
        //    if (part.gameObject.tag == "Fire" || part.gameObject.tag == "Steam")
        //    {
        //        part.Play();
        //    }
        //}
    } 

    //void Update()
    //{
    //    //null reference in here?
    //    foreach(ParticleSystem part in particles)
    //    {
    //        if (part.gameObject.tag == "Fire" || part.gameObject.tag == "Steam")
    //        {
    //            if (part.isEmitting == false)
    //            {
    //                part.Play(true);
    //            }
    //        }
    //    }
    //}

    
    void applyParticles(int numShots)
    {
        if (numShots >= maxShots)
        {
            destructPlane();
        }

        foreach (var child in particles)
        {
            if (child.gameObject.tag == "Fire" || child.gameObject.tag == "Steam")
            {
                if (child.gameObject.activeSelf == false) // turn on particles on first hit
                {
                    //Debug.Log("turning on particles");
                    child.gameObject.SetActive(true);
                }
                else // scale up on subsequent shots
                {
                    //Debug.Log("scaling up subsequently");
                    Vector3 newScale = new Vector3(child.transform.localScale.x + 0.25f, child.transform.localScale.y + 0.25f, child.transform.localScale.z + 0.25f);
                    child.transform.localScale = newScale;
                }
            }
        }
    }

    void destructPlane()
    {
        Debug.Log("WE'RE GOING DOWN BOYS");
    }
}
