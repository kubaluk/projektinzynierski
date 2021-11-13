using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPistol : MonoBehaviour, IAttack
{
    private bool isActive=true;

    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (isActive)
        {
            Transform attackTransform = GameObject.Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
            attackTransform.GetComponent<ProjectilePhysics>().Setup(3f, 3, 20f);
        }
    }

    public void Toggle(bool newState)
    {
        isActive = newState;
    }
}
