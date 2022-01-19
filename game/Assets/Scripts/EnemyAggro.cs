using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class responsible for handling enemy aggro
public class EnemyAggro : MonoBehaviour
{
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }
    
    //toggles the aggro to certain state
    public void Toggle(bool state)
    {
        isActive = state;
    }
    
    //checks current state of enemy aggro
    public bool IsAggressive()
    {
        return isActive;
    }
}
