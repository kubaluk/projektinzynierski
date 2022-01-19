using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interface for enemy attack types
public interface IEnemyAttack
{
    //creates a projectile according to attack type towards aim point position
    public void Attack(Transform aimPoint, Transform projectilePrefab);
    
}
