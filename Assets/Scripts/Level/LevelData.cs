using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData : MonoBehaviour
{
    public int levelNumber;
    public int numberOfBottles;
    public float timerLimit;            // Timer limit (0 if no timer)
    public int checkLimit;              // number of checks allowed (0 if no limit)
    
    public LevelData(int levelNumber, int numberOfBottles, float timerLimit, int checkLimit)
    {
        this.levelNumber = levelNumber;
        this.numberOfBottles = numberOfBottles;
        this.timerLimit = timerLimit;
        this.checkLimit = checkLimit;
    }


    public void GetLevelData()
    {
        Debug.Log("Level " + this.levelNumber);
        Debug.Log("Number of bottles: " + this.numberOfBottles);
    }
}
