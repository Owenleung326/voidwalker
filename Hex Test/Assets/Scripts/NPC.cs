using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject Sceen;
    public GameObject player;
    public bool inrange;
    public TMP_Text text;
    private float num = 1;

    public InventoryScriptableObject NPCInventory;
    public GameObject NPCInventoryScreen;
    public GameObject InteractScreen;

    public void OnTriggerStay(Collider other)
    {   
        if (other.tag == "Player")
        {
            inrange = true;
            InteractScreen.SetActive(true);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inrange)
        {
            text.color = new Color(0, 0, 0);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            InteractScreen.SetActive(false);

            transform.LookAt(player.transform);

            Sceen.SetActive(true);

            NPCInventoryScreen.SetActive(true);

            text.text = "Welcome";
        }
    }

    public void OnTriggerExit()
    {
        inrange = false;
        num = 0;
    }

    public void OnButtonPress()
    {
        switch (num)
        {
            case 4:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                Sceen.SetActive(false);

                NPCInventoryScreen.SetActive(false);
                break;
            case 3:
                text.text = "next time see you";
                break;
            case 2:
                text.text = "items give you";
                break;
            case 1:
                text.text = "Money give me";
                break;
            default:
                Debug.Log("error");
                break;
        }
        num++;
    }
}
