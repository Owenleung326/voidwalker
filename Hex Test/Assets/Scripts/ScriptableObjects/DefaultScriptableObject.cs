using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default", menuName = "Inventory System/Items/Default", order = 1)]
public class DefaultScriptableObject : ItemScriptableObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
