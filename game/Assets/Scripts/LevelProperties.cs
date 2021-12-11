using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelProperties", menuName = "ScriptableObjects/LevelProperties", order = 4)]
public class LevelProperties : ScriptableObject
{
    public int levelWidth;
    public int levelHeight;
    public float percentToFill;
    public float chanceWalkerChangeDir;
    public float chanceWalkerSpawn;
    public float chanceWalkerDestroy;
    public int maxWalkers;
    public int iterationSteps;
    
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public GameObject playerObject;
    public int amountOfEnemies;
    public List<GameObject> enemyTypes;
    
}
