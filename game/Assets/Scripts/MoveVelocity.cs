using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//move velocity using rigidbody
public class MoveVelocity : MonoBehaviour, IMovement
{
    //move speed set in editor
    [SerializeField] private float moveSpeed;
    
    private Vector3 velocityVector;
    private Rigidbody2D rigidbody2D;
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2D.velocity = velocityVector * moveSpeed;
    }
    public void SetVelocity(Vector3 velocity)
    {
        this.velocityVector = velocity;
    }
}
