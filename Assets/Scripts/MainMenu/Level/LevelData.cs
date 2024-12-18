using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelData : MonoBehaviour
{
    [SerializeField] int levelNumber;
    [SerializeField] int numberOfBottles;
    [SerializeField] float timeLimit;            // Timer limit (0 if no timer)
    [SerializeField] int checkLimit;              // number of checks allowed (0 if no limit)
    [SerializeField] ECheckMode checkMode = ECheckMode.ButtonCheck;     // default
    [SerializeField] Button levelButton;

    public bool isUnlocked = false; 
    
    public int LevelNumber { get { return levelNumber; } set { levelNumber = value; } }
    public int NumberOfBottles { get { return numberOfBottles; } set { numberOfBottles = value; } }

    public float TimeLimit { get { return timeLimit; } set { timeLimit = value; } }
    public int CheckLimit { get {return checkLimit; } set { checkLimit = value; } }

    public ECheckMode CheckMode { get { return checkMode; } set { checkMode = value; } }
    
    public bool IsUnlocked { get; set; }

    public void UnLocked()
    {
        isUnlocked = true;
        levelButton.interactable = true;
    }

}
