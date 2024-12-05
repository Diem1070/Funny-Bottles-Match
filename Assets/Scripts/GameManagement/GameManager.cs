using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

/* Manage main logic of the game: Initialize, win/lose, reset */
public class GameManager : MonoBehaviour
{
    public EGameMode currentGameMode;       // save current game mode
    private GameModeManager gameModeManager;

    // reference to timer and checker
    [SerializeField] Timer timer;
    [SerializeField] Checker checker;


    private int numberOfBottle;
    [SerializeField] TMP_Text matchedBottlesText;            // display number of matched bottles 
    [SerializeField] TMP_Text levelNumberText;

    // Fields for initializing bottles
    int numberOfBottles;
    [SerializeField] GameObject[] bottlePrefabs;

    [SerializeField] Transform parentTransform;               // put in GamePlay Area object

    [SerializeField] float distanceBetweenBottles;
    [SerializeField] float sampleBottlesPosition;
    [SerializeField] float playedBottlesPosition;
    [SerializeField] float selectedBottleHeightOffset;   // UI bottle selected

    [SerializeField] LevelModeManager levelModeManagerObject;
    [SerializeField] CustomModeManager customModeManagerObject;

    private BottleManager bottleManager;
    private BottleEvent bottleEvent;

    // -------------------------------------

    private bool isGameRunning = true;          // flag controls game state


    void Start()
    {

        InitializeGameMode();
        
        InitializeGame();

        matchedBottlesText.text = $"Match: 0/{numberOfBottles}";

        checker.OnCheck.AddListener(CheckGameStatus);
        timer.OnComplete.AddListener(isTimeOver);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning) return;     // stop game if end game

        timer.StartTimer();


        // Check mouse click on bottle
        if (Input.GetMouseButtonDown(0)) // 0 is left click
        {
            bottleEvent.DetectBottleClick(bottleManager);

            if (checker.GetCheckMode() == ECheckMode.AutoCheck)
            {
                checker.AutoCheck();
            }
        }
    }

    void InitializeGameMode()
    {
        currentGameMode = GameModeSelection.Instance.GetGameMode();
        Debug.Log("GameManager - game mode: " + currentGameMode.ToString());


        if (currentGameMode == EGameMode.Level)
        {
            gameModeManager = levelModeManagerObject;
            gameModeManager.Initialize();
            levelNumberText.text = $"Level {levelModeManagerObject.GetLevelNumber()}";
        }
        else if (currentGameMode == EGameMode.Custom)
        {
            gameModeManager = customModeManagerObject;
            gameModeManager.Initialize();
            levelNumberText.text = "Custom";
        }
    }
    

    void InitializeGame()
    {
        // Bottles
        numberOfBottles = gameModeManager.GetNumberOfBottles();
        bottleManager = new BottleManager(numberOfBottles, bottlePrefabs, distanceBetweenBottles, sampleBottlesPosition, playedBottlesPosition, parentTransform);
        bottleManager.InitializeBottles();

        bottleEvent = new BottleEvent(selectedBottleHeightOffset);

        // other UI element
        timer.timeLimit = gameModeManager.GetTimeLimit();
        checker.SetCheckLimit(gameModeManager.GetCheckLimit());
        checker.SetCheckMode(gameModeManager.GetCheckMode());

        // Check if using timer or not
        if (timer.timeLimit == 0)
        {
            timer.gameObject.SetActive(false);
        }
        else
        {
            timer.gameObject.SetActive(true);
            
        }
    }

    void CheckGameStatus()
    {
        int matchedBottles = bottleManager.CountMatchedBottles();
        matchedBottlesText.text = $"Match: {matchedBottles}/{numberOfBottles}";

        if (matchedBottles == numberOfBottles)
        {
            Success();
        }
    }

    void isTimeOver()
    {
        Debug.Log("Time is Over!");
        GameOver();
    }

    void Success()
    {
        Debug.Log("Success!");
        timer.StopTimer();  
        EndGame(true);          // isWin = true
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        EndGame(false);         // isWin = false
    }

    // Method to finish game
    void EndGame(bool isWin)
    {
        // Stop all things in GamePlay
        isGameRunning = false;

        if (isWin)
        {
            GameStateManager.Instance.ChangeState(EGameState.Success);
        }
        else
        {
            GameStateManager.Instance.ChangeState(EGameState.GameOver);
        }

        foreach (GameObject bottle in bottleManager.playedBottles)
        {
            SetBottleColor(bottle, Color.white);
        }

        foreach (GameObject bottle in bottleManager.sampleBottles)
        {
            SetBottleColor(bottle, Color.white);
        }
    }

    
    void SetBottleColor(GameObject bottle, Color color)
    {
        Bottle bottleRenderer = bottle.GetComponent<Bottle>();
        bottleRenderer.SetColor(color);
    } 
}
