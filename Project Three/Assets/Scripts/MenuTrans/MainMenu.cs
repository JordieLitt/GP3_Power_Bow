using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public GameObject pauseMenu;
   public GameObject startFresh;

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

    if(CrystalChecker.instance.crystals == 0)
    {
      startFresh.SetActive(false);
    }
    else
    {
      startFresh.SetActive(true);
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

   public void ExploreMode()
   {
     SceneManager.LoadScene("InsideOfHub");
   }

   public void NewGame()
   {
     CrystalChecker.instance.crystals = 0;
     SceneManager.LoadScene("HubBlockout");
   }
   public void LoadGame()
   {
     SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
   }

   public void QuitGame()
   {
      PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
       Application.Quit();
   }

     public void RestartGame()
   {
       SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene"));
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

   public void ReturnHome()
   {
     SceneManager.LoadScene("InsideOfHub");
   }


}
