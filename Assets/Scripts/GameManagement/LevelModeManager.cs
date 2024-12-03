using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModeManager : GameModeManager
{
    LevelData levelData;


    public override void Initialize()
    {
        levelData = LevelManager.Instance.GetLevelData();
        numberOfBottles = levelData.NumberOfBottles;
        Debug.Log("Level: " + levelData.ToString());

        timeLimit = levelData.TimeLimit;
        checkLimit = levelData.CheckLimit;
    }

    public override void HandleSuccess()
    {

    }

    public override void HandleFailure()
    {

    }

    public override void EndGame()
    {

    }
}
