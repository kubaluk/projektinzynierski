using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnemyKillable : MonoBehaviour, IKillable
{
    public void Kill()
    {
        Debug.Log("explosion.gif");
        Destroy(gameObject);
    }
}
