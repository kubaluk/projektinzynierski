using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePhysics : MonoBehaviour
{
    //projectile damage dealt to enemies
    int bulletDamage;
    // Start is called before the first frame update
    public void Setup(float flightTime, int damage, float speed)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //add force to an object into certain direction to make it move
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        bulletDamage = damage;

        //destroy a projectile after set time if it doesn't hit anything
        Destroy(gameObject, flightTime);
    }

    //if the projectile hits enemy they take damage, if it hits the wall it only destroys itself
    private void OnTriggerEnter(Collider other)
    {
        /*TODO: enemy class and interface
         IEnemy enemy = other.GetComponent<IEnemy>();
        if (enemy != null)
        {
            enemy.takeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
}
