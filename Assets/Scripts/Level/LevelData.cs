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
    [SerializeField] Image[] star;



    public int LevelNumber { get { return levelNumber; } set { levelNumber = value; } }
    public int NumberOfBottles { get { return numberOfBottles; } set { numberOfBottles = value; } }

    public float TimeLimit { get { return timeLimit; } set { timeLimit = value; } }
    public int CheckLimit { get {return checkLimit; } set { checkLimit = value; } }
    
    public Image[] Star { get { return star; } set { star = value; } }

}
