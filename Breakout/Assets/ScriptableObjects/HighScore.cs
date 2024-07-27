using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "Tools/HighScore", order = 0)]
public class HighScore : PersistentHighScore
{
    public int score = 0;
    public int highScoreEasy = 10000;
    public int highScoreMedium = 10000;
    public int highScorehard = 10000;
}
