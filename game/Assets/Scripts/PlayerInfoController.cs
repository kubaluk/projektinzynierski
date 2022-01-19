using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles configuring player info Scriptable Object
public class PlayerInfoController : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    //sets current attack delay
    public void SetAttackDelay(float newDelay)
    {
        playerInfo.attackDelay = newDelay;
    }

    //sets current position of player
    public void SetPlayerPosition(Vector3 newPosition)
    {
        playerInfo.playerPosition = newPosition;
    }
}
