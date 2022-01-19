using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//class responsible for setting a "Begin game" button active when two weapons are chosen
public class BeginCheck : MonoBehaviour
{

    [SerializeField] private GameObject beginButton;

    [SerializeField] private PlayerStats playerStats1;
    
    [SerializeField] private PlayerStats playerStats2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // checks if both weapons are selected, if they do then sets the button object active
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
