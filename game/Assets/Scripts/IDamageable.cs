using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interface responsible for handling taking damage
public interface IDamageable
{
    //makes object take a set amount of damage and make extra actions depending on object
    public void TakeDamage(int damage);
}
