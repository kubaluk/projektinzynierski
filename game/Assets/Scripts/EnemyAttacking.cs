using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    
    [SerializeField] private Transform attackPoint;
    
    [SerializeField] private Transform projectilePrefab;

    private EnemyAggro aggro;

    private IEnemyAttack attackType;

    private float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        attackTimer = 0f;
        attackType = GetComponent<IEnemyAttack>();
        aggro = GetComponent<EnemyAggro>();
    }

    // Update is called once per frame
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
