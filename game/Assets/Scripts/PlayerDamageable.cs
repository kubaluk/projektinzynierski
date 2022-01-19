using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles player taking damage
public class PlayerDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStats stats;

    //remove a set amount of health from player and invoke an event
    public void TakeDamage(int damage)
    {
        EventSystem.Current.PlayerDamaged();
        stats.health -= damage;
    }
}
