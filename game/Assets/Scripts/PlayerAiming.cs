using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private Transform anchorPoint;
    [SerializeField] private Transform aimPoint;
    [SerializeField] private SpriteRenderer weaponSprite;
    [SerializeField] private SpriteRenderer meleeSprite;
    [SerializeField] private SpriteRenderer rangedSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimDirection = (anchorPoint.localPosition - this.transform.localPosition).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if (angle < -90 || angle > 90)
        {
            weaponSprite.flipY = true;
            meleeSprite.flipX = true;
            rangedSprite.flipX = true;
        }
        else
        {
            weaponSprite.flipY = false;
            meleeSprite.flipX = false;
            rangedSprite.flipX = false;
        }
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
