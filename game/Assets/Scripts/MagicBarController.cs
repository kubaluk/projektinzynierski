using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handles magic bar on UI
public class MagicBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Magic magic;

    private float currentCooldown;
    //sets slider max value to magic max value
    public void Start()
    {
        slider.maxValue = magic.maxMagicAmount;
    }
    //update amount of magic on slider
    public void Update()
    {
        slider.value = magic.MagicAmount;
    }
}
