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

    public void SwapButtonPressed()
    {
        ONSwapButtonPressed?.Invoke();
    }
}
