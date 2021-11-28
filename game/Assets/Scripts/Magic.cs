using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Magic", menuName = "ScriptableObjects/Magic", order = 2)]
public class Magic : ScriptableObject
{
    public int magicAmount;
    public int maxMagicAmount;
    public int magicGainAmount;
    public int magicSpendAmount;

}

