using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Settings", menuName ="Tools/Settings", order =1)]
public class Settings : PersistentHighScore
{
    public float BallSpeed = 40;
    public Edifficulty  DifficultyLevel= Edifficulty.easy;

    public enum Edifficulty
    {
        easy,
        normal,
        hard
    }

    public void ChangeSpeed(float newSpeed)
    {
        BallSpeed = newSpeed;
    }

    public void ChangeDifficulty(int newDifficulty)
    {
        DifficultyLevel = (Edifficulty)newDifficulty;
    }
}
