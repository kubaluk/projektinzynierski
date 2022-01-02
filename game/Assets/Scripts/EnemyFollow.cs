using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private EnemyAggro aggro;

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private float targetDistance;
    
    private Vector3 GetFollowIntent()
    {
        Vector3 intention = Vector3.zero;
        Vector3 localPosition = this.transform.localPosition;
        Vector3 otherPosition = playerInfo.playerPosition;
        Vector3 direction = otherPosition - localPosition;
        float distance = Vector3.Distance(localPosition, otherPosition);
        
        var springStrength = (distance - targetDistance);
        intention += direction * springStrength;
        return intention.magnitude < 0.5f ? Vector3.zero : intention.normalized;
    }
    
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
            GetComponent<IMovement>().SetVelocity(GetFollowIntent());
        }
    }
}
