using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationEventInvoker : MonoBehaviour
{
    [SerializeField] private AliveEnemies aliveEnemies;

    [SerializeField] private PlayerStats meleeStats;

    [SerializeField] private PlayerStats rangedStats;

    private float startLevelTimer;
    // Start is called before the first frame update
    void Start()
    {
        startLevelTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(startLevelTimer<=5)
            startLevelTimer += Time.deltaTime;
        if (aliveEnemies.Enemies.Count == 0 && startLevelTimer >= 5)
        {
            EventSystem.Current.GameWon();
        }

        if (meleeStats.health <= 0 || rangedStats.health <= 0)
        {
            EventSystem.Current.GameLost();
        }
    }
}
