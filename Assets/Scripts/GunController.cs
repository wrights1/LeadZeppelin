using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public AudioClip clip;
    public AudioSource audioSource;

    public GameObject targetPlane;
    public Transform gunTip;

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
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            audioSource.PlayOneShot(clip);
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

            if (hit.collider.gameObject.CompareTag("GreenPlane"))
            {
                Debug.Log("found plane");
                numShots += 1;
                targetPlane.SendMessage("applyParticles", numShots);
            }
        }
    }
}
