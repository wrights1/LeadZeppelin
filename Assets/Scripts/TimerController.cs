using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public int timeLimitInSeconds;
    private float time;
    [SerializeField] private Text timerLabel;
    [SerializeField] private GameObject LossMenu;

    private bool lost= false;

    void Start()
    {
        time = timeLimitInSeconds;
        timerLabel.text = "3:00";
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            string newTime = string.Format("{0}:{1}", minutes, seconds);
            timerLabel.text = newTime;
        }
        else
        {
            if (lost == false)
            {
                timerLabel.text = "00:00";
                Time.timeScale = 0.0f;
                LossMenu.SetActive(true);
                lost = true;
            }
            
        }
    }
}
