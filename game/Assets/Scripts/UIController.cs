using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles the UI events
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject blinkScreen;
    
    //registers class for player damaged event
    void Start()
    {
        EventSystem.Current.ONPlayerDamaged += DamageBlink;
    }

    //if player got damaged, blink the red light
    private void DamageBlink()
    {
        StartCoroutine(BlinkScreen(0.05f));
    }

    //handles the red screen blink
    private IEnumerator BlinkScreen(float time)
    {
        blinkScreen.SetActive(true);
        yield return new WaitForSeconds(time);
        blinkScreen.SetActive(false);
    }

}
