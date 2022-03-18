using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory System/Items/Weapon", order = 3)]

public class WeaponScriptableObject : ItemScriptableObject
{
    public float atk;
    public float def;

    public void Awake()
    {
        type = ItemType.Weapon;
    }

    override public void UseItem()
    {
        //Do the thing specific to this item/ Aka weapon
        

    }

}
