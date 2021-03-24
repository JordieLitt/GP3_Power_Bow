using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
  void start()
  {
    UnlockMouse();
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
       SceneManager.LoadScene("Art Prototype");
   }

     public void ExitMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }
}
