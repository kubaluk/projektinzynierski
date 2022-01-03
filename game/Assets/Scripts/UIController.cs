using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject blinkScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Current.ONPlayerDamaged += DamageBlink;
    }

    private void DamageBlink()
    {
        StartCoroutine(BlinkScreen(0.05f));
    }

    private IEnumerator BlinkScreen(float time)
    {
        blinkScreen.SetActive(true);
        yield return new WaitForSeconds(time);
        blinkScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
