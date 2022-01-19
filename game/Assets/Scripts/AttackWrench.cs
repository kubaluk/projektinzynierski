using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack type - wrench, standard melee attack
public class AttackWrench : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay;

    private void Awake()
    {
        attackDelay = 0.7f;
    }
    //create melee attack prefab, scale it and setup physics
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (!isActive) return;
        var newObject = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        newObject.transform.localScale = new Vector3(2, 2, 1);
        newObject.GetComponent<MeleePhysics>().Setup(new Vector2(1.1f, 1.1f), 3, 10, 5);
    }

    public float GetDelay()
    {
        return attackDelay;
    }

    public void Toggle(bool newState)
    {
        isActive = newState;
    }
}
