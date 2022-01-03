using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private Score score;

    private void LoseGame()
    {
        SceneManager.LoadScene("Scenes/LoseScreen");
    }

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
    
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Current.ONGameLost += LoseGame;
        EventSystem.Current.ONGameWon += WinGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
