using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused = false;


    public void Pause()
    {
        isPaused = true;
    }
    public void Resume()
    {
        isPaused=false;
    }
}
