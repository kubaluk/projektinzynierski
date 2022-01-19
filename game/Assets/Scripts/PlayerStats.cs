using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object responsible for holding player character statistics such as health or activity
[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int health;
    public int maxHealth;
    public float speed;
    public IAttack CurrentWeapon;
    public bool isActive;
    public Sprite weaponSprite;

    public void ResetHealth()
    {
        health = maxHealth;
    }
}
