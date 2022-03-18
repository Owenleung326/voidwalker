using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory System/Items/Potion", order = 2)]
public class PotionScriptableObject : ItemScriptableObject
{
    public int restoreValue;

    public void Awake()
    {
        type = ItemType.Potion;
    }

    public override void UseItem()
    {
       
    }
}
