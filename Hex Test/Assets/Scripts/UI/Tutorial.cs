using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject movementTutorial;
    public GameObject battleTutorial;
    public int num = 0;

    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        movementTutorial.SetActive(true);
        Time.timeScale = 0;
    }


    public void OnbuttonPress()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(movementTutorial);
        num++;
        if (num == 2)
        {
            Destroy(battleTutorial);
        }
    }
}
