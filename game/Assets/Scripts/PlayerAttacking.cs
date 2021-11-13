using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform projectilePrefab;
    private IAttack attackType;
    private void Start()
    {
        EventSystem.Current.ONAttackButtonPressed += PlayerAttacking_OnAttack;
        attackType = GetComponent<IAttack>();
    }

    private void PlayerAttacking_OnAttack()
    {
        attackType.Attack(attackPoint, projectilePrefab);
    }
}
