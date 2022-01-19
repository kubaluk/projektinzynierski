using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles melee attack physics
public class MeleePhysics : MonoBehaviour
{
    //projectile damage dealt to enemies
    int bulletDamage;
    private Vector2 attackRange;
    [SerializeField] private LayerMask targetLayers;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private Vector2 tmpRange;

    [SerializeField] private Magic magic;
    
    private static readonly int Attack = Animator.StringToHash("Attack");

    //creates a collider box that checks if it hit a target, if yes then it takes damage, projectile disappears after a second
    public void Setup(Vector2 range, int damage, float power, int gainAmount)
    {
        attackRange = range;
        //animator.SetTrigger(Attack);
        var hitTargets = Physics2D.OverlapBoxAll(transform.position, attackRange, transform.rotation.z ,targetLayers);
        foreach (var target in hitTargets)
        {
            magic.GainMagic(gainAmount);
            target.GetComponent<IDamageable>().TakeDamage(damage);
            if(!target.CompareTag("Player"))
                target.GetComponent<EnemyKnockback>().KnockAway(power);
        }
        //destroy a projectile after set time if it doesn't hit anything
        Destroy(gameObject, 1f);
    }

    //show a collider box in unity editor
    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;
        Gizmos.DrawWireCube(attackPoint.position, tmpRange);
    }
}
