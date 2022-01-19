using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handle enemy knockback
public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //knock the enemy away from player with a set power
    public void KnockAway(float power)
    {
        Vector3 direction = (transform.position - playerInfo.playerPosition).normalized;
        rb.AddForce(direction*power, ForceMode2D.Impulse);
    }

}
