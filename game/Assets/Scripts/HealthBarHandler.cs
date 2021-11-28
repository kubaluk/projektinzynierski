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

    private float currentCooldown;
    public void Start()
    {
        EventSystem.Current.ONSwapButtonPressed += SwapBars;
        currentCooldown = 0;
    }

    public void Update()
    {
        currentCooldown += Time.deltaTime;
    }

    public void SetHealthBar()
    {
        slider.value = stats.health;
    }

    public void SetMaxHealth()
    {
        slider.value = stats.maxHealth;
    }

    private void SwapBars()
    {
        if(currentCooldown>swapCooldown){
            StartCoroutine(FadeBar(stats.isActive));
            currentCooldown = 0;
        }
    }

    private IEnumerator FadeBar(bool isActive, int fadeSpeed = 5)
    {
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
                stats.isActive = true;
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
                stats.isActive = false;
                yield return null;
            }
        }
    }
}
