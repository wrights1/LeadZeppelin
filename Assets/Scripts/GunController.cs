using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public AudioClip clip;
	public AudioClip shoot;
    public AudioSource audioSource;
    public Transform gunTip;
    public string hitTag;
	public ParticleSystem mf;
	public ParticleSystem mf2;
	public GameObject startScreen;
	public GameObject pauseScreen;
	public GameObject winScreen;
	public GameObject loseScreen;

    private int numShots = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }


    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

		//mf.Play();
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("SHOOTIN THAT MF THANG");
			if (startScreen.activeSelf || pauseScreen.activeSelf || winScreen.activeSelf || loseScreen.activeSelf)
			{
				audioSource.PlayOneShot(shoot);  // Don't want to have "zeppelin" be the sound in menu selections
			}
			else
			{
				audioSource.PlayOneShot(clip);
			}
			if (mf)
			{
				mf.Play();
			}
			if (mf2)
			{
				mf2.Play();  // need for second gun on airplane
			}
            RaycastGun();
        }
    }

    private void RaycastGun()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunTip.transform.position, gunTip.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "ColorCube")
            {
                Debug.Log("found cube");
                Destroy(hit.collider.gameObject);
            }

            if (hit.collider.gameObject.CompareTag(hitTag))
            {
                Debug.Log("hit plane");
                numShots += 1;
                hit.collider.gameObject.SendMessageUpwards("applyParticles");
            }
        }
    }
}
