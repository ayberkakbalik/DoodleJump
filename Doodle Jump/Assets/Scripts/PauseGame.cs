using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool pause = false;

    public void Pause_Game()
    {
        if (pause == false)  // Oyun devam ediyorsa
        {
            Time.timeScale = 0f;  // durdur
            pause = true;
        }
        else
        {
            Time.timeScale = 1f;  // 
            pause = false;
        }
    }
}
