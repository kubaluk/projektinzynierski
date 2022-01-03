using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem Current;

    private void Awake()
    {
        Current = this;
    }

    public event Action ONSwapButtonPressed;
    public event Action ONAttackButtonPressed;
    public event Action ONPauseButtonPressed;
    public event Action ONGameLost;
    public event Action ONGameWon;
    public event Action ONPlayerDamaged;

    public void SwapButtonPressed()
    {
        ONSwapButtonPressed?.Invoke();
    }

    public void AttackButtonPressed()
    {
        ONAttackButtonPressed?.Invoke();
    }
    public void PauseButtonPressed()
    {
        ONPauseButtonPressed?.Invoke();
    }
    
    public void GameLost()
    {
        ONGameLost?.Invoke();
    }
    
    public void GameWon()
    {
        ONGameWon?.Invoke();
    }
    
    public void PlayerDamaged()
    {
        ONPlayerDamaged?.Invoke();
    }
}
