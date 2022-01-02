using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Image blackoutSquare;
    [SerializeField] private float swapCooldown;
    private bool previousState;

    private float currentCooldown;
    public void Start()
    {
        //EventSystem.Current.ONSwapButtonPressed += SwapBars;
        previousState = stats.isActive;
        slider.maxValue = stats.maxHealth;
        currentCooldown = 0;
    }

    public void Update()
    {
        //currentCooldown += Time.deltaTime;
        slider.value = stats.health;
        if (previousState != stats.isActive)
        {
            StartCoroutine(FadeBar(stats.isActive));
        }
    }

    public void SetMaxHealth()
    {
        slider.value = stats.maxHealth;
    }

    private void SwapBars()
    {
        if(currentCooldown>swapCooldown){
            StartCoroutine(FadeBar(stats.isActive));
            stats.isActive = !stats.isActive;
            currentCooldown = 0;
        }
    }

    private IEnumerator FadeBar(bool isActive, int fadeSpeed = 5)
    {
        previousState = stats.isActive;
        Color fadeColor = blackoutSquare.color;
        float fadeAmount;
        
        if (!isActive)
        {
            transform.SetAsFirstSibling();
            while (blackoutSquare.color.a < 0.7)
            {
                fadeAmount = fadeColor.a + (fadeSpeed * Time.deltaTime);

                fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
                blackoutSquare.color = fadeColor;
                
                yield return null;
            }
        }
        else
        {
            transform.SetAsLastSibling();
            while (blackoutSquare.color.a > 0)
            {
                fadeAmount = fadeColor.a - (fadeSpeed * Time.deltaTime);

                fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
                blackoutSquare.color = fadeColor;
                
                yield return null;
            }
        }
    }
}
