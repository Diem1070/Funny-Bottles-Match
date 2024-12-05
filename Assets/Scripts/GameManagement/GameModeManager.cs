using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameModeManager : MonoBehaviour 
{
    // set default for fields
    protected int numberOfBottles = 10;     
    protected float timeLimit = 0;
    protected int checkLimit = 0;
    protected ECheckMode checkMode = ECheckMode.ButtonCheck;

    public int GetNumberOfBottles()
    {
        return numberOfBottles;
    }

    public float GetTimeLimit()
    {
        return timeLimit;
    }

    public int GetCheckLimit()
    {
        return checkLimit;
    }

    public ECheckMode GetCheckMode()
    {
        return checkMode;
    }

    public abstract void Initialize();
    //public abstract void StartGame();

    public abstract void HandleSuccess();
    public abstract void HandleFailure();
    public abstract void EndGame();

    protected void CommonLogic()
    {

    }
}
