using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object responsible for holding information about the amount of active enemies on the level
[CreateAssetMenu(fileName = "AliveEnemies", menuName = "ScriptableObjects/AliveEnemies", order = 6)]
public class AliveEnemies : ScriptableObject
{
    //private list of enemies, not available for other objects
    private List<IEnemy> enemies;
    //public list of enemies, used by other objects to communicate with private list
    public List<IEnemy> Enemies { get => enemies;  private set => enemies = value;  }

    //on start of the scene create a new list of enemies
    private void OnEnable()
    {
        enemies = new List<IEnemy>();
    }

    //register a new enemy on the list
    public void RegisterEnemy(IEnemy enemy)
    {
        Enemies.Add(enemy);
    }

    //remove an enemy from the list
    public void UnregisterEnemy(IEnemy enemy)
    {
        Enemies.Remove(enemy);
    }
    
    //check the current amount of alive enemies
    public int EnemiesCount()
    {
        return Enemies.Count;
    }
}
