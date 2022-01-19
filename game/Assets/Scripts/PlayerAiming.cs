using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles player rotation towards cursor 
public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private Transform anchorPoint;
    [SerializeField] private Transform aimPoint;
    [SerializeField] private SpriteRenderer weaponSprite;
    [SerializeField] private PlayerStats meleeStats;
    [SerializeField] private PlayerStats rangedStats;

    //set an active weapon sprite
    void Start()
    {
        weaponSprite.sprite = meleeStats.isActive ? meleeStats.weaponSprite : rangedStats.weaponSprite;
    }

    //rotates weapon towards cursor and flip the sprite in case it would be upside down due to rotation
    void Update()
    {
        weaponSprite.sprite = meleeStats.isActive ? meleeStats.weaponSprite : rangedStats.weaponSprite;
        Vector3 aimDirection = (anchorPoint.localPosition - this.transform.localPosition).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if (angle < -90 || angle > 90)
        {
            weaponSprite.flipY = true;
        }
        else
        {
            weaponSprite.flipY = false;
        }
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
