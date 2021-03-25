using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public GameObject pauseMenu;
  public static bool isPaused = false;
  void start()
  {
    UnlockMouse();
  }

   void Update()
    {
    if(Input.GetKeyDown(KeyCode.Escape))
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

  
  void UnlockMouse()
  {
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }

   public void StartGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void QuitGame()
   {
       Application.Quit();
   }

     public void RestartGame()
   {
       SceneManager.LoadScene("Forest Level");
   }

     public void ExitMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }

   public void PauseGame()
   {
      pauseMenu.SetActive(true);
      Time.timeScale = 0f;
      isPaused = true;
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
   }

   public void ResumeGame()
   {
      pauseMenu.SetActive(false);
      Time.timeScale = 1f;
      isPaused = false;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
   }
}
