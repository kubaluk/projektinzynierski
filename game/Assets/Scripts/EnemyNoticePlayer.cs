using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoticePlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    [SerializeField] private float minNoticeDistance;

    private Transform playerChild;

    private Vector3 playerLocation;

    private Vector3 direction;

    private float distance;

    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        mask=LayerMask.GetMask($"Wall");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerChild = playerObject.transform.GetChild(1);
        playerLocation = playerChild.localPosition;
        Debug.Log(playerLocation);
        
        distance = Vector3.Distance(playerLocation, transform.position);
        if (distance < minNoticeDistance)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, mask);
            if (hit2D.collider != null)
            {
                Debug.Log("Found you!");
            }
            else
            {
                Debug.Log("Someone's here");
            }
        }
    }
}
