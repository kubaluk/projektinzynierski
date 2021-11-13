using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventInvoker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            EventSystem.Current.SwapButtonPressed();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EventSystem.Current.AttackButtonPressed();
        }
    }
}
