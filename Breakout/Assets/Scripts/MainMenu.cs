using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject StartMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void EndGame()
    {
        Application.Quit();
    }

    public void ShowSettings()
    {
        StartMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void ShowMainMenu()
    {
        SettingsMenu.SetActive(false);
        StartMenu.SetActive(true); 
    }
}
