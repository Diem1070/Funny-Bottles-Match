using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameModeManager : MonoBehaviour 
{
    protected int numberOfBottles;
    protected float timeLimit = 0;
    protected int checkLimit = 0;

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

    public abstract void Initialize();
    //public abstract void StartGame();

    public abstract void HandleSuccess();
    public abstract void HandleFailure();
    public abstract void EndGame();

    protected void CommonLogic()
    {

    }
}
