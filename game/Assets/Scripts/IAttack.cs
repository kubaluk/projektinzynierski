using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    //public void Attack(Vector3 attackPosition, Vector3 attackDirection, Transform projectilePrefab);
    public void Attack(Transform aimPoint, Transform projectilePrefab);

    public void Toggle(bool newState);
}
