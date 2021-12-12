using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Magic magic;

    private float currentCooldown;
    public void Start()
    {
        slider.maxValue = magic.maxMagicAmount;
    }

    public void Update()
    {
        slider.value = magic.MagicAmount;
    }
}
