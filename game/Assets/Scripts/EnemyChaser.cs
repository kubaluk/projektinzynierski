using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour, IEnemy
{
    [SerializeField] private AliveEnemies aliveEnemies;
    // Start is called before the first frame update
    void Start()
    {
        aliveEnemies.RegisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
