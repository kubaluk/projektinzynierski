using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTurret : MonoBehaviour, IEnemyAttack
{
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        Transform attackTransform = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        attackTransform.GetComponent<EnemyProjectilePhysics>().Setup(3f, 2, 10f, 0);
    }
    
}
