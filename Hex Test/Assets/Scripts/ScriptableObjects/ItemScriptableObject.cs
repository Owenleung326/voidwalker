using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public enum ItemType
{
    Weapon,
    Potion,
    Default
}

public abstract class ItemScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
   // public Image icon;

    [TextArea(15,20)]
    public string description;

    public virtual void UseItem()
    {

    }
}
