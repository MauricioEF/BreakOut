using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform transformScore;
    public Transform transformHighScore;
    public TMP_Text textScore;
    public TMP_Text textHighScore;
    public HighScore highScoreSO; //SO Stands For (Scriptable Object)
    public Settings settings;
    private int selectedHighScore;
    private void Awake()
    {
        switch (settings.DifficultyLevel)
        {
            case Settings.Edifficulty.easy:
                selectedHighScore = highScoreSO.highScoreEasy;
                break;
            case Settings.Edifficulty.normal:
                selectedHighScore = highScoreSO.highScoreMedium;
                break;
            case Settings.Edifficulty.hard:
                selectedHighScore = highScoreSO.highScorehard;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transformScore = GameObject.Find("Score").transform;
        textScore = transformScore.GetComponent<TMP_Text>();
        transformHighScore = GameObject.Find("HighScore").transform;
        textHighScore = transformHighScore.GetComponent<TMP_Text>();
        highScoreSO.Load();
        textHighScore.text = $"HighScore: {selectedHighScore}";
        highScoreSO.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = $"Score: {highScoreSO.score}";
        if(highScoreSO.score > selectedHighScore)
        {
            Debug.Log("Should Save the HighScore");
            selectedHighScore = highScoreSO.score;
            switch (settings.DifficultyLevel)
            {
                case Settings.Edifficulty.easy:
                    highScoreSO.highScoreEasy = highScoreSO.score;
                    break;
                case Settings.Edifficulty.normal:
                    highScoreSO.highScoreMedium = highScoreSO.score;
                    break;
                case Settings.Edifficulty.hard:
                    highScoreSO.highScorehard = highScoreSO.score;
                    break;
            }
            textHighScore.text = $"HighScore: {selectedHighScore}";
            highScoreSO.Save();
            //PlayerPrefs.SetInt("HighScore", highScoreSO.highScore);
        }
    }

    public void IncreaseScore(int points)
    {
        Debug.Log("Increasing score");
        highScoreSO.score += points;
    }
}
