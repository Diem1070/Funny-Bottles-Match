using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/* Manage main logic of the game: Initialize, win/lose, reset */
public class GameManager : MonoBehaviour
{
    public EGameMode currentGameMode;       // save current game mode
    private GameModeManager gameModeManager;

    // reference to timer and checker
    public Timer timer;
    public Checker checker;

    private LevelData levelData;

    [SerializeField] TMP_Text matchedBottlesText;            // display number of matched bottles 


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

    private void Awake()
    {
        // initialize components in GameManager

    }

    void Start()
    {

        InitializeGameMode();
        
        InitializeGame();

        matchedBottlesText.text = $"Match: 0/{numberOfBottles}";

        checker.OnCheckPressed.AddListener(CheckGameStatus);
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
        }
    }

    void InitializeGameMode()
    {
        currentGameMode = GameModeSelection.Instance.GetGameMode();
        Debug.Log("Game Manager::game mode: " + currentGameMode.ToString());


        if (currentGameMode == EGameMode.Level)
        {
            gameModeManager = levelModeManagerObject;
        }
        else if (currentGameMode == EGameMode.Custom)
        {
            gameModeManager = customModeManagerObject;
        }
    }
    

    void InitializeGame()
    {
        gameModeManager.Initialize();
        numberOfBottles = gameModeManager.GetNumberOfBottles();
        timer.timeLimit = gameModeManager.GetTimeLimit();
        checker.checkLimit = gameModeManager.GetCheckLimit();


        // Bottles
        bottleManager = new BottleManager(numberOfBottles, bottlePrefabs, distanceBetweenBottles, sampleBottlesPosition, playedBottlesPosition, parentTransform);
        bottleManager.InitializeBottles();

        bottleEvent = new BottleEvent(selectedBottleHeightOffset);

        // Check if using timer or not
        if (timer.timeLimit == 0)
        {
            timer.gameObject.SetActive(false);
        }
        else
        {
            timer.gameObject.SetActive(true);
            
        }

        // check if using checkLimit or not
        if (checker.checkLimit == 0)
        {
            checker.checkText.text = "Check";
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

        if(isWin)
        {
            // Pop up Success Panel (with congratulation effect) and Results (if game mode is Level)
            GameStateManager.Instance.ShowSuccessPanel();
        }
        else
        {
            // Pop up GameOver Panel (with fail effect)
            GameStateManager.Instance.ShowOverPanel();
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
