using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWrench : MonoBehaviour, IAttack
{
    private bool isActive=true;

    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (!isActive) return;
        var newObject = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        newObject.transform.localScale = new Vector3(3, 3, 1);
        newObject.GetComponent<MeleePhysics>().Setup(0.5f, 3, 1);
    }

    public void Toggle(bool newState)
    {
        isActive = newState;
    }
}
