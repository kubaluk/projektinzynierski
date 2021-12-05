using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    public void Toggle(bool state)
    {
        isActive = state;
    }

    public bool IsAggressive()
    {
        return isActive;
    }
}
