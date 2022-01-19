using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy attack type - melee
public class EnemyMeleeAttack : MonoBehaviour, IEnemyAttack
{
    //create a melee attack prefab, scale it and setup physics
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        var newObject = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        newObject.transform.localScale = new Vector3(2, 2, 1);
        newObject.GetComponent<MeleePhysics>().Setup(new Vector2(1.1f, 1.1f), 3, 1, 0);
    }
}
