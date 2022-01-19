using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack type - machine gun, rapid but inaccurate ranged attack
public class AttackMachineGun : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay;

    private void Awake()
    {
        attackDelay = 0.1f;
    }
    //create ranged attack prefab in set amount of copies and determine it's angle for recoil, then setup physics
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (isActive)
        {
            Quaternion recoil = aimPoint.rotation;
            recoil.eulerAngles = new Vector3(recoil.eulerAngles.x, recoil.eulerAngles.y,
                recoil.eulerAngles.z + Random.Range(-10f, 10f));
            Transform attackTransform = GameObject.Instantiate(projectilePrefab, aimPoint.position, recoil);
            attackTransform.localScale += new Vector3(-0.25f, -0.25f, 0);
            attackTransform.GetComponent<ProjectilePhysics>().Setup(3f, 2, 15f, 1);
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
