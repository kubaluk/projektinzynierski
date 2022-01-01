using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            Debug.Log(weaponType);
        }
        else
        {
            description.SetActive(false);
            playerStats.CurrentWeapon = null;
            playerStats.weaponSprite = null;
            Debug.Log(playerStats.CurrentWeapon);
        }
    }

    private void Update()
    {
        if (description.activeSelf&&!thisToggle.isOn)
        {
            description.SetActive(false);
        }
    }
}
