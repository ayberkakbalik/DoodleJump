using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(DoodleJumpConstants.MAIN_SCENE_NAME);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(DoodleJumpConstants.MAIN_MENU_NAME);
    }
}
