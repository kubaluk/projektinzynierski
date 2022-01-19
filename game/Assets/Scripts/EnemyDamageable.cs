using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//class responsible for handling enemy taking damage
public class EnemyDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private SpriteRenderer hitObject;
    private int health;

    private float blinkTime;
    private float currentTime;
    private bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        blinkTime = 0.1f;
        currentTime = 0;
        waiting = false;
    }
    //highlight enemy, make a hit stop and check if enemy is killed
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Highlight());
        if(!waiting)
            StartCoroutine(HitStop(0.05f));
        StartCoroutine(HitStopCooldown(1f));
        StartCoroutine(WaitForHitStop());
    }
    //highlight enemy for a split second to indicate hit
    private IEnumerator Highlight()
    {
        hitObject.enabled = true;
        yield return new WaitForSeconds(blinkTime);
        hitObject.enabled = false;
    }
    //stop time for a split second for hit effect
    private IEnumerator HitStop(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
    //check if hit stop has passed to check if enemy got killed
    private IEnumerator WaitForHitStop()
    {
        while (Time.timeScale != 1.0f) yield return null;
        if (health < 0)
        {
            GetComponent<IKillable>().Kill();
        }
    }
    //limit hit stops to not lag the game
    private IEnumerator HitStopCooldown(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        waiting = false;
    }
}
