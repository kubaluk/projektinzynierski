using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 7)]
public class Score : ScriptableObject
{
    public int score;

    public void ResetScore()
    {
        score = 0;
    }

    public string DisplayScore()
    {
        return "Score: " + score;
    }

    public void SummarizeLevel(float time)
    {
        score += (int) time * 100;
    }
    
}
