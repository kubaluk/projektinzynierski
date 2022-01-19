using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//handles changing levels and ending the game
public class GameEnder : MonoBehaviour
{
    [SerializeField] private Score score;

    //if the game was lost, change the scene to lose screen
    private void LoseGame()
    {
        SceneManager.LoadScene("Scenes/LoseScreen");
    }

    //if the level was won, change the scene according to the current scene
    private void WinGame()
    {
        score.SummarizeLevel(TimerController.instance.GetRemainingTime());
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneManager.LoadScene("Scenes/Level2");
                break;
            case "Level2":
                SceneManager.LoadScene("Scenes/Level3");
                break;
            case "Level3":
                SceneManager.LoadScene("Scenes/WinScreen");
                break;
        }
    }
    
    //register event listener for winning and losing game
    void Start()
    {
        EventSystem.Current.ONGameLost += LoseGame;
        EventSystem.Current.ONGameWon += WinGame;
    }
    
}
