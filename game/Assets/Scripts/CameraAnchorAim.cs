using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchorAim : MonoBehaviour, ICameraAnchor
{
    //object that should be followed by camera
    [SerializeField] private GameObject anchoredObject;
    //limits how far camera can go from character
    [SerializeField] private float reachLimit;
    //position of anchor point
    private Vector3 anchorPosition;
    private Vector3 tmpAnchor;
    //sets new position for anchor point
    public void SetPosition(Vector3 position)
    {
        Vector3 anchoredObjectPosition = anchoredObject.GetComponent<Transform>().position;
        tmpAnchor = (anchoredObjectPosition + position)*reachLimit;
        tmpAnchor = (tmpAnchor + anchoredObjectPosition) * reachLimit;
        this.anchorPosition = tmpAnchor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Transform>().position = anchorPosition;

    }
}
