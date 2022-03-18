using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingMenu;

    public void OnStartButtonPress()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnSettingButtonPress()
    {
        MainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void OnExitButtonPress()
    {
        Application.Quit();
    }

    public void OnBackButtonPress()
    {
        MainMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }
}
