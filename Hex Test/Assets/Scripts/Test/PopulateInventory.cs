using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopulateInventory : MonoBehaviour
{

    public InventoryScriptableObject inventory;

    public List<Image> inventorySlots = new List<Image>();

    private void OnEnable()
    {
        int i = 0;
        foreach(Image slot in inventorySlots)
        {
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
