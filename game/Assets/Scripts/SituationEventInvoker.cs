using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationEventInvoker : MonoBehaviour
{
    [SerializeField] private AliveEnemies aliveEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aliveEnemies.Enemies.Count == 0)
        {
            EventSystem.Current.AllEnemiesKilled();
        }
    }
}
