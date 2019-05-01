using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPause : MonoBehaviour
{

    public GameObject startCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("setting time to 0 in StartPause");
        Time.timeScale = 0f;
    }

    public void unPause()
    {
        Debug.Log("unpausing");
        startCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
