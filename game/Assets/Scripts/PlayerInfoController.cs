using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoController : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    public void SetAttackDelay(float newDelay)
    {
        playerInfo.attackDelay = newDelay;
    }

    public void SetPlayerPosition(Vector3 newPosition)
    {
        playerInfo.playerPosition = newPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
