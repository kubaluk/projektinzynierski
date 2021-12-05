using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    private EnemyAggro aggro;
    
    // Start is called before the first frame update
    void Start()
    {
        aggro = GetComponent<EnemyAggro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aggro.IsAggressive())
        {
            Vector3 aimDirection = (playerInfo.playerPosition - this.transform.localPosition).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
