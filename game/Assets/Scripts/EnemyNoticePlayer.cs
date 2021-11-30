using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoticePlayer : MonoBehaviour
{
    [SerializeField] private float minNoticeDistance;

    private Transform playerObject;

    private Vector3 playerLocation;
    
    private Vector3 direction;

    private LayerMask mask;
    
    // Start is called before the first frame update
    void Start()
    {
        mask=LayerMask.GetMask($"Wall", "Player");
    }

    public void AssignPlayer(Transform playerObj)
    {
        playerObject = playerObj.GetChild(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = playerObject.localPosition;
        direction = (playerLocation - transform.position).normalized;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, minNoticeDistance ,mask);
        if (hit2D)
        {
            if (hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                Debug.Log("I see wall");
            }
            else
            {
                Debug.Log("I see you");
            }
        }
        else
        {
            Debug.Log("I see nothing");
        }
    }
}
