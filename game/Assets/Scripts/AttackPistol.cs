using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack type - pistol, standard ranged attack
public class AttackPistol : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay;

    private void Awake()
    {
        attackDelay = 0.5f;
    }
    //create ranged attack prefab in set amount of copies and determine it's angle for recoil, then setup physics
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
