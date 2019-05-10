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
	[SerializeField] private Text instructions;
	
	[SerializeField] public int numberEnemies;
	[SerializeField] public int enemiesLeft;

    private bool lost= false;
	
	public void subTractEnemy()
	{
		enemiesLeft = enemiesLeft + 1;
	}

    void Start()
    {
        time = timeLimitInSeconds;
        timerLabel.text = "3:00";
		instructions.text = "Use mouse to look and aim \nClick to shoot";
		instructions.gameObject.SetActive(true);
    }

    void Update()
    {
        if (time > 0)
        {
			//Debug.Log(instructions.text);
			if ((timeLimitInSeconds - 30) <= time)  // remove instructions after 30 seconds
			{
				instructions.text = "Use mouse to look and aim \nClick to shoot";
			}
			if ((timeLimitInSeconds - 30) > time)  // remove instructions after 30 seconds
			{
				//Debug.Log("turn off instructions");
				instructions.text = "";
			}
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
