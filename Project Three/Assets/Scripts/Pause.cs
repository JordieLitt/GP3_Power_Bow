using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;

    void Update()
    {
    if(Input.GetKeyDown(KeyCode.Space))
    {
        if(isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    }

    public void PauseGame()
   {
      pauseMenu.SetActive(true);
      Time.timeScale = 0f;
      isPaused = true;
   }

   public void ResumeGame()
   {
      pauseMenu.SetActive(false);
      Time.timeScale = 1f;
      isPaused = false;
   }
}
