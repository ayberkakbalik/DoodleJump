using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadGame() 
   {
        SceneManager.LoadScene(DoodleJumpConstants.MAIN_SCENE_NAME);  
   }

   public void QuitGame()
    {
        Debug.Log("You left the Doodle Jump!"); // Quit tu�u i�e yar�yorsa konsol ekran�nda bu yaz� g�r�lecek.
        Application.Quit();
    }  
}
