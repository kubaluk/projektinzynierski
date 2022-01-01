using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationEventInvoker : MonoBehaviour
{
    [SerializeField] private AliveEnemies aliveEnemies;

    [SerializeField] private PlayerStats meleeStats;

    [SerializeField] private PlayerStats rangedStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aliveEnemies.Enemies.Count == 0)
        {
            EventSystem.Current.GameWon();
        }

        if (meleeStats.health <= 0 || rangedStats.health <= 0)
        {
            EventSystem.Current.GameLost();
        }
    }
}
