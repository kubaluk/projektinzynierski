using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//handles choosing weapon before the game starts
public class WeaponChoosing : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private List<Toggle> otherToggles;

    [SerializeField] private GameObject description;
    
    [SerializeField] private Sprite weaponSprite;

    private IAttack weaponType;

    private Toggle thisToggle;

    private void Start()
    {
        thisToggle = GetComponent<Toggle>();
        weaponType = GetComponent<IAttack>();
        description.SetActive(false);
    }

    //if the weapon was chosen, activate a frame and attach it to player info object
    public void Toggle()
    {
        if (thisToggle.isOn)
        {
            foreach (var toggle in otherToggles)
            {
                if (toggle.isOn)
                {
                    toggle.isOn = false;
                }
            }
            description.SetActive(true);
            playerStats.CurrentWeapon = weaponType;
            playerStats.weaponSprite = weaponSprite;
        }
        else
        {
            description.SetActive(false);
            playerStats.CurrentWeapon = null;
            playerStats.weaponSprite = null;
        }
    }

    //display active weapon description
    private void Update()
    {
        if (description.activeSelf&&!thisToggle.isOn)
        {
            description.SetActive(false);
        }
    }
}
