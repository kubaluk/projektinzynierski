using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovementController : MonoBehaviour
{
    private void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        GetComponent<IMovement>().SetVelocity(moveDirection);
    }
}
