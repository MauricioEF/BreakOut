using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    public Transform TransformScore;
    public TMP_Text textScore;
    public HighScore ScoreSO;

    private void OnEnable()
    {
        TransformScore = GameObject.Find("GameOverScore").transform;
        textScore = TransformScore.GetComponent<TMP_Text>();
        Debug.Log(textScore);
        Debug.Log(ScoreSO.score);
        Debug.Log(textScore.text);
        textScore.text = $"Final Score: {ScoreSO.score}";
    }
}
