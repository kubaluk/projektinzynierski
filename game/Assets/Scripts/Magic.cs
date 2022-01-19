using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Object for handling current amount of magic
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
    
    //spends a set amount of magic
    public void SpendMagic(int amount)
    {
        MagicAmount -= amount;
    }

    //replenishes a set amount of magic
    public void GainMagic(int amount)
    {
        MagicAmount += amount;
    }

    //checks if the magic meter is empty
    public bool Empty()
    {
        return MagicAmount == 0;
    }
}

