using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        if (settingsMenu.activeInHierarchy)
        {
            settingsMenu.SetActive(false);
        }
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void ReturnToMainScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowSettingsMenu()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
