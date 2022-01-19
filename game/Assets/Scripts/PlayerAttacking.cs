using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles player attacking
public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private PlayerStats playerStats;
    private IAttack attackType;
    
    //register class for attack event and set active attack type
    private void Start()
    {
        EventSystem.Current.ONAttackButtonPressed += PlayerAttacking_OnAttack;
        attackType = playerStats.CurrentWeapon;
    }
    
    //if event is invoked, make an attack according to attack type
    private void PlayerAttacking_OnAttack()
    {
        attackType.Attack(attackPoint, projectilePrefab);
    }
}
