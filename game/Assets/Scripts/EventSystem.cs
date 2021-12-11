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
    public event Action ONAllEnemiesKilled;

    public void SwapButtonPressed()
    {
        ONSwapButtonPressed?.Invoke();
    }

    public void AttackButtonPressed()
    {
        ONAttackButtonPressed?.Invoke();
    }

    public void AllEnemiesKilled()
    {
        ONAllEnemiesKilled?.Invoke();
    }
}
