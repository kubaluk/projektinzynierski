using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeginCheck : MonoBehaviour
{

    [SerializeField] private GameObject beginButton;

    [SerializeField] private PlayerStats playerStats1;
    
    [SerializeField] private PlayerStats playerStats2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats1.CurrentWeapon!=null && playerStats2.CurrentWeapon!=null)
        {
            beginButton.SetActive(true);
        }
        else
        {
            beginButton.SetActive(false);
        }
    }
}
