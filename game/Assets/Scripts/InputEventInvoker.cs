using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//invokes events that use input from keyboard or mouse
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
        
    //if game is unpaused, check if buttons were pressed and invoke a correct event
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            EventSystem.Current.PauseButtonPressed();
        }

        if (!PauseMenu.gameIsPaused)
        {
            currentTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                EventSystem.Current.SwapButtonPressed();
            }
            
            if (Input.GetKey(KeyCode.Mouse0) && currentTime >= playerInfo.attackDelay)
            {
                EventSystem.Current.AttackButtonPressed();
                currentTime = 0;
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                TimerController.instance.BeginTimer();
            }
        }
    }
}
