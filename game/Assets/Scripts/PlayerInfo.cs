using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object responsible for holding information about player object
[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects/PlayerInfo", order = 4)]
public class PlayerInfo : ScriptableObject
{
    public Vector3 playerPosition;

    public float attackDelay;
}
