using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
}
