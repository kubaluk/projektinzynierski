using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHammer : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay = 1.5f;

    private PlayerInfoController playerInfoController;

    private void Awake()
    {
        playerInfoController = GetComponent<PlayerInfoController>();
        attackDelay = 1.5f;
    }
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (!isActive) return;
        var newObject = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        newObject.transform.localScale = new Vector3(3, 3, 1);
        newObject.GetComponent<MeleePhysics>().Setup(new Vector2(1.8f, 1.8f), 3, 1, 5);
    }

    public void Toggle(bool newState)
    {
        isActive = newState;
        if(newState)playerInfoController.SetAttackDelay(attackDelay);
    }
}
