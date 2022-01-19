using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fix the rotation of an object
public class FixRotation : MonoBehaviour
{
    Quaternion rotation;
    private Vector3 position;
    //get the start rotation and position
    void Awake()
    {
        rotation = transform.rotation;
        position = transform.position;
    }
    //set the start rotation and position every frame
    void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = position;
    }
}
