using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack type - screwdriver, rapid but weak melee attack
public class AttackScrewdriver : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay;

    private void Awake()
    {
        attackDelay = 0.3f;
    }
    //create melee attack prefab, scale it and setup physics
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (!isActive) return;
        var newObject = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        newObject.transform.localScale = new Vector3(1f, 1f, 1);
        newObject.GetComponent<MeleePhysics>().Setup(new Vector2(0.5f, 0.5f), 2, 3, 10);
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
