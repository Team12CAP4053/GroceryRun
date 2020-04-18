using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        if (((SceneManager.GetActiveScene().buildIndex == 2) || (SceneManager.GetActiveScene().buildIndex == 3)) && Input.anyKeyDown)
        { 
            FadeToNextLevel(); 
        }
          
        //if (Input.GetMouseButtonDown(1))
        //{
        //    FadeToNextLevel();
        //}
    }

    public void FadeToNextLevel ()
    {
        FadeToLevel((SceneManager.GetActiveScene().buildIndex + 1) % 8);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
