using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;

    public void OnResumeButtonPressed()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Menu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnBackMenuButtonPressed()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
