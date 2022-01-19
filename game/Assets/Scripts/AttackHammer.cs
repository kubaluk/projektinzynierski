using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack type - hammer, slow but strong melee attack
public class AttackHammer : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay;

    private void Awake()
    {
        attackDelay = 1.2f;
    }
    //create melee attack prefab, scale it and setup physics
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (!isActive) return;
        var newObject = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        newObject.transform.localScale = new Vector3(3, 3, 1);
        newObject.GetComponent<MeleePhysics>().Setup(new Vector2(1.8f, 1.8f), 8, 20, 5);
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
