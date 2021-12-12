using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScrewdriver : MonoBehaviour, IAttack
{
    private bool isActive=true;

    private float attackDelay = 0.5f;

    private PlayerInfoController playerInfoController;

    private void Awake()
    {
        playerInfoController = GetComponent<PlayerInfoController>();
        attackDelay = 0.5f;
    }
    public void Attack(Transform aimPoint, Transform projectilePrefab)
    {
        if (!isActive) return;
        var newObject = Instantiate(projectilePrefab, aimPoint.position, aimPoint.rotation);
        newObject.transform.localScale = new Vector3(2f, 1f, 1);
        newObject.GetComponent<MeleePhysics>().Setup(new Vector2(1.1f, 0.5f), 3, 1, 25);
    }

    public void Toggle(bool newState)
    {
        isActive = newState;
        if(newState)playerInfoController.SetAttackDelay(attackDelay);
    }
}
