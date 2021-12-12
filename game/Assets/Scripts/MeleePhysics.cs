using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    public void Setup(Vector2 range, int damage, float speed, int gainAmount)
    {
        attackRange = range;
        //animator.SetTrigger(Attack);
        var hitTargets = Physics2D.OverlapBoxAll(transform.position, attackRange, transform.rotation.x ,targetLayers);
        foreach (var target in hitTargets)
        {
            Debug.Log("test");
            magic.GainMagic(gainAmount);
            target.GetComponent<IDamageable>().TakeDamage(damage);
        }
        //destroy a projectile after set time if it doesn't hit anything
        Destroy(gameObject, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        if (!attackPoint) return;
        Gizmos.DrawWireCube(attackPoint.position, tmpRange);
    }
}
