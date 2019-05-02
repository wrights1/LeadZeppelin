using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string CurrentSceneName;
    public string NextSceneName;
    public string MainMenuName = "Main Menu";

    public void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void NextScene()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene(NextSceneName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(CurrentSceneName);
    }
}
