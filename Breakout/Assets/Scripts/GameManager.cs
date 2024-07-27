using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Settings settings;
    public bool isPaused = false;


    private void Awake()
    {
        Debug.Log(settings.DifficultyLevel);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
