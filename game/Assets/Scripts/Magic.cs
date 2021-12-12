using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Magic", menuName = "ScriptableObjects/Magic", order = 2)]
public class Magic : ScriptableObject
{

    public int maxMagicAmount;
    public int magicAmount;

    public int MagicAmount
    {
        get => magicAmount;
        private set {
            magicAmount = value;
            if (magicAmount < 0) magicAmount = 0;
            else if (magicAmount > maxMagicAmount) magicAmount = maxMagicAmount;
        }
    }

    public void SpendMagic(int amount)
    {
        MagicAmount -= amount;
    }

    public void GainMagic(int amount)
    {
        MagicAmount += amount;
    }

    public bool Empty()
    {
        return MagicAmount == 0;
    }
}

