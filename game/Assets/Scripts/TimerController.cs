using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    [SerializeField] private TextMeshProUGUI timeCounter;

    [SerializeField] private Vector2 levelTimeLimit;

    private float timeLimit;

    private float timeRemaining;

    private TimeSpan timePlaying;

    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "00:00.00";
        if (levelTimeLimit.y > 59) levelTimeLimit.y = 59;
        BeginTimer();
    }

    public float GetRemainingTime()
    {
        return timeRemaining;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
        timeLimit = levelTimeLimit.x * 60 + levelTimeLimit.y;
        timeRemaining = timeLimit;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            timeRemaining = timeLimit - elapsedTime;
            elapsedTime += Time.deltaTime;
            timePlaying=TimeSpan.FromSeconds(timeRemaining);
            if (timeRemaining <= 0)
            {
                EventSystem.Current.GameLost();
                break;
            }
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public void StopTimer()
    {
        timerGoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
