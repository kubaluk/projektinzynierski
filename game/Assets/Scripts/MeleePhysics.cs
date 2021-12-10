using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePhysics : MonoBehaviour
{
    //projectile damage dealt to enemies
    int bulletDamage;
    private float attackRange;
    [SerializeField] private LayerMask targetLayers;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private float tmpRange;

    private static readonly int Attack = Animator.StringToHash("Attack");

    // Start is called before the first frame update
    public void Setup(float range, int damage, float speed)
    {
        attackRange = range;
        //animator.SetTrigger(Attack);
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, attackRange, targetLayers);
        foreach (var target in hitTargets)
        {
            target.GetComponent<IDamageable>().TakeDamage(damage);
            Debug.Log("ouch");
        }
        //destroy a projectile after set time if it doesn't hit anything
        Destroy(gameObject, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;
        Gizmos.DrawWireSphere(attackPoint.position, tmpRange);
    }
}
