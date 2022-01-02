using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] private GameObject pauseScreen;

    private void Start()
    {
        EventSystem.Current.ONPauseButtonPressed += HandlePauseButton;
    }

    private void HandlePauseButton()
    {
        if (!gameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    private void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true); 
    }

    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
