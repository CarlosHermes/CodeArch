using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Rune")]

public class RuneObject : ItemObject
{
    public float atkBonus;
    private void Awake()
    {
        type = ItemType.Rune;
    }

}
