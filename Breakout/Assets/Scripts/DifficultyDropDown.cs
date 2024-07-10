using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyDropDown : MonoBehaviour
{
    public Settings settings;
    private TMP_Dropdown difficulty;

    private void Awake()
    {
        difficulty = GetComponent<TMP_Dropdown>();
        difficulty.value = (int)settings.DifficultyLevel;
    }
    private void Start()
    {
        difficulty = GetComponent<TMP_Dropdown>();
        Debug.Log(difficulty);
        Debug.Log(settings);
        difficulty.onValueChanged.AddListener(
        delegate
        {
            settings.ChangeDifficulty(difficulty.value);
        });
    }
}
