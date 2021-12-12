using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMachineGun : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay = 0.1f;

    private PlayerInfoController playerInfoController;

    private void Awake()
    {
        playerInfoController = GetComponent<PlayerInfoController>();
        attackDelay = 0.1f;
    }
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (isActive)
        {
            Quaternion recoil = aimPoint.rotation;
            recoil.eulerAngles = new Vector3(recoil.eulerAngles.x, recoil.eulerAngles.y,
                recoil.eulerAngles.z + Random.Range(-10f, 10f));
            Transform attackTransform = GameObject.Instantiate(projectilePrefab, aimPoint.position, recoil);
            attackTransform.localScale += new Vector3(-0.25f, -0.25f, 0);
            attackTransform.GetComponent<ProjectilePhysics>().Setup(3f, 3, 20f, 1);
        }
    }

    public void Toggle(bool newState)
    {
        isActive = newState;
        if(newState)playerInfoController.SetAttackDelay(attackDelay);
    }
}
