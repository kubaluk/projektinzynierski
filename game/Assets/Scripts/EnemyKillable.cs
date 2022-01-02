using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyKillable : MonoBehaviour, IKillable
{
    [SerializeField] private AliveEnemies aliveEnemies;
    public void Kill()
    {
        aliveEnemies.UnregisterEnemy(GetComponent<IEnemy>());
        Destroy(gameObject);
    }
}
