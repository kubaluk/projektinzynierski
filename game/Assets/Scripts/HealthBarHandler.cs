using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handles player character health bar
public class HealthBarHandler : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Image blackoutSquare;
    [SerializeField] private float swapCooldown;
    private bool previousState;

    //sets the activity for health bar and sets the bar scale according to max health
    public void Start()
    {
        //EventSystem.Current.ONSwapButtonPressed += SwapBars;
        previousState = stats.isActive;
        slider.maxValue = stats.maxHealth;
    }
    
    //change according to player health and swap bars if the state changes
    public void Update()
    {
        //currentCooldown += Time.deltaTime;
        slider.value = stats.health;
        if (previousState != stats.isActive)
        {
            StartCoroutine(FadeBar(stats.isActive));
        }
    }

    //fades to black and back to normal according to activity of the character
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
