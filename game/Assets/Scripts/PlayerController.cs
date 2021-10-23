using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private enum PlayerState{Active, Follow, Swap};

    [SerializeField] private PlayerState state;
    private PlayerState previousState;
    [SerializeField] private GameObject movePoint;
    [SerializeField] private GameObject otherCharacter;
    [SerializeField] private float swapTime;
    [SerializeField] private GameObject playerSprite;
    private Renderer spriteRenderer;
    private float t;

    private void OnSwapButton()
    {
        if (state != PlayerState.Swap)
        {
            previousState = state;
            spriteRenderer.sortingOrder = (int) state;
            state = PlayerState.Swap;
            t = 0;
        }
    }

    private void Swap()
    {
        t += Time.deltaTime;
        if (t / swapTime < 1)
        {
            switch (previousState)
            {
                case PlayerState.Active:
                    transform.position = movePoint.transform.position;
                    break;
                case PlayerState.Follow:
                    transform.localPosition = Vector3.Lerp(transform.localPosition,movePoint.transform.localPosition, t/swapTime);
                    break;
            }
        }
        else
        {
            switch (previousState)
            {
                case PlayerState.Active:
                    state = PlayerState.Follow;
                    break;
                case PlayerState.Follow:
                    state = PlayerState.Active;
                    break;
            }
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        EventSystem.Current.ONSwapButtonPressed += OnSwapButton;
        spriteRenderer = playerSprite.GetComponent<Renderer>();
        t = 0;
    }
    
    

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case PlayerState.Active:
                transform.position = movePoint.transform.position;
                break;
            case PlayerState.Follow:
                //TODO: following script
                break;
            case PlayerState.Swap:
                Swap();
                break;
        }
    }
}
