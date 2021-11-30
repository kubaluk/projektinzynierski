using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects/PlayerInfo", order = 4)]
public class PlayerInfo : ScriptableObject
{
    public Vector3 playerPosition;
}
