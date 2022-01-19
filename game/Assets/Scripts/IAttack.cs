using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack type interface
public interface IAttack
{
    //creates a projectile according to attack type towards aim point position
    public void Attack(Transform aimPoint, Transform projectilePrefab);
    //gets attack's delay
    public float GetDelay();
    //toggles the activity of attack type
    public void Toggle(bool newState);
}
