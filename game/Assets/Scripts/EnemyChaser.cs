using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy type - chaser
public class EnemyChaser : MonoBehaviour, IEnemy
{
    [SerializeField] private AliveEnemies aliveEnemies;
    //register enemy on enemy list
    void Start()
    {
        aliveEnemies.RegisterEnemy(this);
    }
}
