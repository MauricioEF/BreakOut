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

    // Start is called before the first frame update
    void Start()
    {
        transformScore = GameObject.Find("Score").transform;
        textScore = transformScore.GetComponent<TMP_Text>();
        transformHighScore = GameObject.Find("HighScore").transform;
        textHighScore = transformHighScore.GetComponent<TMP_Text>();
        //if (PlayerPrefs.HasKey("HighScore"))
        //{
        //highScoreSO.highScore = PlayerPrefs.GetInt("HighScore");
        //}
        highScoreSO.Load();
        textHighScore.text = $"HighScore: {highScoreSO.highScore}";
        highScoreSO.score = 0;
    }

    private void FixedUpdate()
    {
        highScoreSO.score += 100;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = $"Score: {highScoreSO.score}";
        if(highScoreSO.score > highScoreSO.highScore)
        {
            highScoreSO.highScore = highScoreSO.score;
            textHighScore.text = $"HighScore: {highScoreSO.highScore}";
            highScoreSO.Save();
            //PlayerPrefs.SetInt("HighScore", highScoreSO.highScore);
        }
    }
}
