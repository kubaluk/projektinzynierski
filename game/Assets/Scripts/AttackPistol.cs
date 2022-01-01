using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPistol : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay;

    private void Awake()
    {
        attackDelay = 0.5f;
    }
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (isActive)
        {
            Transform attackTransform = GameObject.Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
            attackTransform.GetComponent<ProjectilePhysics>().Setup(3f, 4, 20f, 2);
        }
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
