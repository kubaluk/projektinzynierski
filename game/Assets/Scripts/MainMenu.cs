using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//handles main menu actions
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Score score;
    
    //begins a new game on first level
    public void BeginGame()
    {
        SceneManager.LoadScene("Scenes/Level1");
        score.ResetScore();
    }
    //quits the app
    public void Quit()
    {
        Debug.Log("Successful quit");
        Application.Quit();
    }
    //finishes the current game and sends the player back to menu
    public void BackToMenu()
    {
        if (PauseMenu.gameIsPaused)
        {
            PauseMenu.gameIsPaused = false;
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("MainMenu");
    }
}
