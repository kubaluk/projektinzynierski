using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//force based movement used by chaser enemy to speed up towards player
public class ForceBasedMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float speed;

    Rigidbody2D rb;
    void Awake () {
        rb = GetComponent<Rigidbody2D> ();
    }

    //attach a force to enemy towards a direction until it reaches max acceleration
    private void AccelerateTo (Vector2 targetVelocity, float maxAccel) {
        Vector2 deltaV = targetVelocity - rb.velocity;
        Vector2 accel = deltaV / Time.fixedDeltaTime;
        if (accel.sqrMagnitude > maxAccel * maxAccel) {
            accel = accel.normalized * maxAccel;
        }
        rb.AddForce (accel, ForceMode2D.Force);
    }
    
    //move towards target at certain speed
    public void SetVelocity(Vector3 velocity)
    {
        AccelerateTo (velocity * speed, 5f);
    }
    
    //get the current velocity
    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }
}
