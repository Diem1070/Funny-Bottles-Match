using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameModeManager
{
    protected int numberOfBottles;

    BottleManager bottleManager;
    BottleEvent BottleEvent;



    public abstract void Initialize();
    //public abstract void StartGame();

    public abstract void HandleSuccess();
    public abstract void HandleFailure();
    public abstract void EndGame();

    protected void CommonLogic()
    {

    }
}
