using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Score score;
    
    public void BeginGame()
    {
        SceneManager.LoadScene("Scenes/Level1");
        score.ResetScore();
    }
    public void Quit()
    {
        Debug.Log("Successful quit");
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
