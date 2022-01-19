using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object responsible for determining wall and floor sprites for the level
[CreateAssetMenu(fileName = "Tileset", menuName = "ScriptableObjects/Tileset", order = 3)]
public class Tileset : ScriptableObject
{
    public List<Sprite> walls;
    public List<Sprite> floors;
}
