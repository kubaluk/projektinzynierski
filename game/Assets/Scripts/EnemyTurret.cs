using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy type - turret
public class EnemyTurret : MonoBehaviour, IEnemy
{
    [SerializeField] private AliveEnemies aliveEnemies;
    //register enemy on enemy list
    void Start()
    {
        aliveEnemies.RegisterEnemy(this);
    }
    
}
