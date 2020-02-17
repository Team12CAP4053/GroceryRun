using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("OvalTrackLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
