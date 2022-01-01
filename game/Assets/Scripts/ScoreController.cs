using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Score score;

    [SerializeField] private TextMeshProUGUI scoreText;


    public void ShowScore()
    {
        scoreText.text = score.DisplayScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }
}
