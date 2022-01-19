using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class responsible for handling enemy attacking
public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    
    [SerializeField] private Transform attackPoint;
    
    [SerializeField] private Transform projectilePrefab;

    private EnemyAggro aggro;

    private IEnemyAttack attackType;

    private float attackTimer;
    //start the cooldown timer
    void Start()
    {
        attackTimer = 0f;
        attackType = GetComponent<IEnemyAttack>();
        aggro = GetComponent<EnemyAggro>();
    }

    //if aggressive, attack towards player if the attack cooldown passed and reset cooldown timer
    void Update()
    {
        if (aggro.IsAggressive())
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackCooldown)
            {
                attackType.Attack(attackPoint, projectilePrefab);
                attackTimer = 0;
            }
        }
    }
}
