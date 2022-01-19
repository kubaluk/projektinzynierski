using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//movement controller using keyboard
public class KeyboardMovementController : MonoBehaviour
{
    //set the direction using pressed direction keys and move in set direction
    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        GetComponent<IMovement>().SetVelocity(moveDirection);
    }
}
