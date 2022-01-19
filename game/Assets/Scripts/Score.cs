using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object responsible for handling the current game score
[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 7)]
public class Score : ScriptableObject
{
    public int score;

    //resets the game score
    public void ResetScore()
    {
        score = 0;
    }
    
    //displays current score
    public string DisplayScore()
    {
        return "Score: " + score;
    }

    //counts the score depending on time left
    public void SummarizeLevel(float time)
    {
        score += (int) time * 100;
    }
    
}
