using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyKillable : MonoBehaviour, IKillable
{
    [SerializeField] private AliveEnemies aliveEnemies;
    public void Kill()
    {
        Debug.Log("explosion.gif");
        aliveEnemies.UnregisterEnemy(GetComponent<IEnemy>());
        Destroy(gameObject);
    }
}
