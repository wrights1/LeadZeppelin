using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneParticles : MonoBehaviour
{
    public Component[] particles;
    public int maxShots; // number of times plane must be shot before going down
    public int fireShots; // min number of times to shoot plane before it catches fire
    public int smokeShots; // min number of times to shoot plane before it starts smoking 

    private ParticleSystem fire;
    private ParticleSystem smoke;

    void Start()
    {
        particles = gameObject.GetComponentsInChildren<ParticleSystem>(true);
        foreach(ParticleSystem part in particles)
        {
            if (part.gameObject.tag == "Fire") { fire = part; }
            if (part.gameObject.tag == "Steam") { smoke = part; }
        }
    } 
    
    void applyParticles(int numShots)
    {
        if (numShots >= maxShots)
        {
            destructPlane();
            return;
        }

        if(numShots >= fireShots) // if we have hit enough times to catch fire, determined by fireShots
        {
            if (fire.gameObject.activeSelf == false) // turn on the first time
            {
                fire.gameObject.SetActive(true);
            }
            else //scale up subsequent times
            {
                Vector3 newScale = new Vector3(fire.transform.localScale.x + 0.25f, fire.transform.localScale.y + 0.25f, fire.transform.localScale.z + 0.25f);
                fire.transform.localScale = newScale;
            }
        }

        if (numShots >= smokeShots) // if we have hit enough times to smoke, determined by smokeShots
        {
            if (smoke.gameObject.activeSelf == false) // turn on the first time
            {
                smoke.gameObject.SetActive(true);
            }
            else //scale up subsequent times
            {
                Vector3 newScale = new Vector3(smoke.transform.localScale.x + 0.25f, smoke.transform.localScale.y + 0.25f, smoke.transform.localScale.z + 0.25f);
                smoke.transform.localScale = newScale;
            }
        }
    }

    void destructPlane()
    {
        Debug.Log("WE'RE GOING DOWN BOYS");
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }
}
