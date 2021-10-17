using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camera movement using mouse position
public class MouseCameraMovement : MonoBehaviour
{
    private void Update()
    {
        if (Camera.main is { })
        {
            //get mouse position on screen
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<ICameraAnchor>().SetPosition(mousePosition);
        }
    }
}
