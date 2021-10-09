using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchorAim : MonoBehaviour, ICameraAnchor
{
    [SerializeField] private GameObject anchoredObject;
    [SerializeField] private float reachLimit;

    private Vector3 anchorPosition;
    private Vector3 tmpAnchor;
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
