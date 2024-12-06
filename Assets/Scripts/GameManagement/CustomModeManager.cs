using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomModeManager : GameModeManager
{
    public override void Initialize()
    {
        numberOfBottles = GameSettings.Instance.GetNumberOfBottles();
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

