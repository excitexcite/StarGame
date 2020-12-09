using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool isPaused = false;

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            isPaused = false;
        } 
        else
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            isPaused = true;
        }
    }
}
