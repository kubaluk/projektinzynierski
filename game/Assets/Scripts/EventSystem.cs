using System;
using UnityEngine;

//class responsible for invoking events
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

    //invoke event if swap button was pressed
    public void SwapButtonPressed()
    {
        ONSwapButtonPressed?.Invoke();
    }

    //invoke event if attack button was pressed
    public void AttackButtonPressed()
    {
        ONAttackButtonPressed?.Invoke();
    }
    
    //invoke event if pause button was pressed
    public void PauseButtonPressed()
    {
        ONPauseButtonPressed?.Invoke();
    }
    
    //invoke event if game was lost
    public void GameLost()
    {
        ONGameLost?.Invoke();
    }
    
    //invoke event if game was won
    public void GameWon()
    {
        ONGameWon?.Invoke();
    }
    
    //invoke event if player got damaged
    public void PlayerDamaged()
    {
        ONPlayerDamaged?.Invoke();
    }
}
