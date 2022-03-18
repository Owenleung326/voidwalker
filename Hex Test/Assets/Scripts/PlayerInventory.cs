using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryScriptableObject inventory;
    public GameObject InventoryScreen;
    public GameObject pickUpSign;
    public bool collideItem;
    public bool playerCollected;
    public bool screen;
    
    public GameObject objectToCollect;

    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        Debug.Log(other.tag);

        if (other.tag != "Item")
        {
            return;
        }

        pickUpSign.SetActive(true);

        objectToCollect = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        objectToCollect = null;
        pickUpSign.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    public void Awake()
    {
        screen = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && InventoryScreen.activeSelf == false)
        {
            InventoryScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else if (Input.GetKeyDown(KeyCode.G) && InventoryScreen.activeSelf == true)
        {
            InventoryScreen.SetActive(false);
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(objectToCollect != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Item item = objectToCollect.GetComponent<Item>();
                if (item)
                {
                    inventory.AddItem(item.item, 1);
                    Destroy(objectToCollect.gameObject);
                    Reset();
                }
            }
        }
    }

    public void Reset()
    {
        pickUpSign.SetActive(false);
    }



}


