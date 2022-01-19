using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handle noticing player by enemy if they get too close
public class EnemyNoticePlayer : MonoBehaviour
{
    [SerializeField] private float minNoticeDistance;

    [SerializeField] private float loseDistance;

    [SerializeField] private PlayerInfo playerInfo;
    
    private EnemyAggro aggro;

    private Vector3 playerLocation;
    
    private Vector3 direction;

    private LayerMask mask;
    
    // Start is called before the first frame update
    void Start()
    {
        mask=LayerMask.GetMask($"Wall", "Player");
        aggro = GetComponent<EnemyAggro>();
    }

    //send a raycast towards player, if it hits player, change the aggro to true, if player is very far change the aggro to false
    void Update()
    {
        playerLocation = playerInfo.playerPosition;
        direction = (playerLocation - transform.position).normalized;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, minNoticeDistance ,mask);
        if (hit2D)
        {
            if (hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                //Debug.Log("I see wall");
            }
            else
            {
                //Debug.Log("I see you");
                aggro.Toggle(true);
            }
        }
        else
        {
            //Debug.Log("I see nothing");
        }

        if (Vector3.Distance(transform.position, playerLocation) > loseDistance)
        {
            aggro.Toggle(false);
        }
    }
}
