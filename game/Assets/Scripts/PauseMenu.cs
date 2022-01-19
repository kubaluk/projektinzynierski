using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//handles pause menu actions
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] private GameObject pauseScreen;

    //registers the class to pause button event
    private void Start()
    {
        EventSystem.Current.ONPauseButtonPressed += HandlePauseButton;
    }

    //do an action depending if game is paused or not
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

    //stops time in the game and shows pause menu
    private void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true); 
    }

    //resumes time in the game and hides pause menu
    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
