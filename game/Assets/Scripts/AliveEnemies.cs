using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AliveEnemies", menuName = "ScriptableObjects/AliveEnemies", order = 6)]
public class AliveEnemies : ScriptableObject
{
    private List<IEnemy> enemies;
    public List<IEnemy> Enemies { get => enemies;  private set => enemies = value;  }

    private void OnEnable()
    {
        enemies = new List<IEnemy>();
    }

    public void RegisterEnemy(IEnemy enemy)
    {
        Enemies.Add(enemy);
    }

    public void UnregisterEnemy(IEnemy enemy)
    {
        Enemies.Remove(enemy);
    }
}
