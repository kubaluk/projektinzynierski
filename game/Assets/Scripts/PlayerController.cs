using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private enum PlayerState{Active, Follow, Swap};
    
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerState state ;
    [SerializeField] private GameObject movePoint;
    [SerializeField] private GameObject otherCharacter;
    [SerializeField] private float swapTime;
    [SerializeField] private GameObject playerSprite;
    [SerializeField]private float targetDistance;

    private PlayerInfoController playerInfoController;
    private PlayerState previousState;
    private Vector3 swapStartPos;
    private Renderer spriteRenderer;
    private IAttack attackMode;
    private float t;
    
    private void OnSwapButton()
    {
        if (state != PlayerState.Swap)
        {
            previousState = state;
            spriteRenderer.sortingOrder = (int) state;
            state = PlayerState.Swap;
            swapStartPos = transform.localPosition;
            t = 0;
        }
    }

    private void Swap()
    {
        t += Time.deltaTime;
        float divided = t / swapTime;
        if (divided <= 1.0f)
        {
            switch (previousState)
            {
                case PlayerState.Active:
                    transform.position = movePoint.transform.position;
                    break;
                case PlayerState.Follow:
                    transform.localPosition = Vector3.Lerp(swapStartPos,movePoint.transform.localPosition, divided);
                    break;
            }
        }
        else
        {
            switch (previousState)
            {
                case PlayerState.Active:
                    state = PlayerState.Follow;
                    attackMode.Toggle(false);
                    GetComponent<CircleCollider2D>().enabled = false;
                    stats.isActive = false;
                    break;
                case PlayerState.Follow:
                    state = PlayerState.Active;
                    attackMode.Toggle(true);
                    GetComponent<CircleCollider2D>().enabled = true;
                    stats.isActive = true;
                    break;
            }
        }
    }
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        EventSystem.Current.ONSwapButtonPressed += OnSwapButton;
        playerInfoController = GetComponent<PlayerInfoController>();
        spriteRenderer = playerSprite.GetComponent<Renderer>();
        attackMode = GetComponent<IAttack>();
        if(state==PlayerState.Active)attackMode.Toggle(true);
        else attackMode.Toggle(false);
        t = 0;
    }

    private Vector3 GetFollowIntent()
    {
        Vector3 intention = Vector3.zero;
        Vector3 localPosition = this.transform.localPosition;
        Vector3 otherPosition = otherCharacter.transform.localPosition;
        Vector3 direction = otherPosition - localPosition;
        float distance = Vector3.Distance(localPosition, otherPosition);
        
        var springStrength = (distance - targetDistance);
        intention += direction * springStrength;
        return intention.magnitude < 0.5f ? Vector3.zero : intention.normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case PlayerState.Active:
                transform.position = movePoint.transform.position;
                playerInfoController.SetPlayerPosition(transform.localPosition);
                break;
            case PlayerState.Follow:
                GetComponent<IMovement>().SetVelocity(GetFollowIntent());
                break;
            case PlayerState.Swap:
                Swap();
                break;
        }
    }
}
