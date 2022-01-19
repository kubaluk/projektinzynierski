using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles enemy projectile physics
public class EnemyProjectilePhysics : MonoBehaviour
{
    //projectile damage dealt to enemies
    int bulletDamage;

    [SerializeField] private string[] tagsToInteract;

    //moves the projectile for set amount of seconds in set direction according to projectile rotation
    public void Setup(float flightTime, int damage, float speed, int spendAmount)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //add force to an object into certain direction to make it move
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        bulletDamage = damage;

        //destroy a projectile after set time if it doesn't hit anything
        Destroy(gameObject, flightTime);
    }

    //if the projectile hits enemy they take damage, if it hits the wall it only destroys itself
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var tag in tagsToInteract) 
        {
            if (other.CompareTag(tag))
            {
                IDamageable target = other.GetComponent<IDamageable>();
                if (target != null)
                {
                    target.TakeDamage(bulletDamage);
                } 
                Destroy(gameObject);
                return;
            }
        }
    }
}
