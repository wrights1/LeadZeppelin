using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject[] planes;
    public GameObject winMenu;
    private bool won = false;
    private int currPlane = 0;

    void Update()
    {
        if (!won)
        {
            if (currPlane == planes.Length)
            {
                won = true;
                Time.timeScale = 0f;
                winMenu.SetActive(true);
            }
            else
            {
                if (planes[currPlane].activeSelf == false) // current plane is dead, start next one 
                {
                    Debug.Log("killed plane, incrementing");
                    currPlane++;
                    planes[currPlane].SetActive(true);
                }
            }
        }
        else 
        {

        }
    }
}
