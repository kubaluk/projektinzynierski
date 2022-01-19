using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

//handle killing enemy
public class EnemyKillable : MonoBehaviour, IKillable
{
    [SerializeField] private AliveEnemies aliveEnemies;
    //removes an enemy from enemy list and destroy it
    public void Kill()
    {
        aliveEnemies.UnregisterEnemy(GetComponent<IEnemy>());
        Destroy(gameObject);
    }
}
