using Settingo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    private Setting settings;
    public GameObject pauseScreen;
    public GameObject playScreen;
    public LevelChanger level;
    void Start()
    {
        settings = GameSetting.setting;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            if (settings.paused)
            {
                settings.paused = false;
            }
            else
            {
                settings.paused = true;
            }
        }
        
        if (settings.paused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        AudioListener.pause = settings.paused;
        pauseScreen.SetActive(true);
        playScreen.SetActive(false);
    }
    public void Resume()
    {
        settings.paused = false;
        Time.timeScale = 1f;
        AudioListener.pause = settings.paused;
        pauseScreen.SetActive(false);
        playScreen.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Resume();
        AudioListener.pause = true;
        level.FadeToLevel(0);
    }
}
