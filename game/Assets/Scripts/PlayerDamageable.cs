using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStats stats;

    public void TakeDamage(int damage)
    {
        EventSystem.Current.PlayerDamaged();
        stats.health -= damage;
    }
}
