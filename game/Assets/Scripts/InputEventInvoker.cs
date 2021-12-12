using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventInvoker : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo playerInfo;

    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }
        
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            EventSystem.Current.SwapButtonPressed();
        }

        if (Input.GetKey(KeyCode.Mouse0)&&currentTime>=playerInfo.attackDelay)
        {
            EventSystem.Current.AttackButtonPressed();
            currentTime = 0;
        }
    }
}
