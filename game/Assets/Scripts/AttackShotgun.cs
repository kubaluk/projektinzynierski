using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//attack type - shotgun, slow but strong ranged attack
public class AttackShotgun : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay;

    private void Awake()
    {
        attackDelay = 1.3f;
    }
    //create ranged attack prefab in set amount of copies and determine it's angle for recoil, then setup physics
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (isActive)
        {
            for (int i = 0; i < 10; i++)
            {
                Quaternion rotation = aimPoint.rotation;
                rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y,
                    rotation.eulerAngles.z + Random.Range(-10, 10));
                Transform attackTransform =
                    GameObject.Instantiate(projectilePrefab, aimPoint.position, rotation);
                float randomScale = Random.Range(-0.25f, 0.25f);
                attackTransform.localScale += new Vector3(randomScale, randomScale, 0);
                attackTransform.GetComponent<ProjectilePhysics>().Setup(0.5f, 1, Random.Range(10f,15f), 1);
            }
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
