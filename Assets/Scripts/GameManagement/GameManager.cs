using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Manage main logic of the game: Initialize, win/lose, reset */
public class GameManager : MonoBehaviour
{
    /*
    private LevelData levelData;
    private Timer timeLimit;
    private Checker checkLimit;
    */ 


    public int numberOfBottles;
    public GameObject[] bottlePrefabs;

    public Transform parentTransform;               // put in GamePlay Area object

    public float distanceBetweenBottles = 2f;
    public float sampleBottlesPosition = -2f;
    public float playedBottlesPosition = 2f;
    public float selectedBottleHeightOffset = 1f; // UI bottle selected

    private BottleManager bottleManager;
    private BottleEvent bottleEvent;

    
    

    void Start()
    {

        //numberOfBottles = GameSettings.Instance.GetNumberOfBottles();
        Debug.Log("Initialize Number Of bottles = " + numberOfBottles);
        
        bottleManager = new BottleManager(numberOfBottles, bottlePrefabs, distanceBetweenBottles, sampleBottlesPosition, playedBottlesPosition, parentTransform);
        bottleManager.InitializeBottles();
        bottleManager.ShufflePlayedBottles();

        bottleEvent = new BottleEvent(selectedBottleHeightOffset);
    }

    // Update is called once per frame
    void Update()
    {
        // Check mouse click on bottle
        if (Input.GetMouseButtonDown(0)) // 0 is left click
        {
            bottleEvent.DetectBottleClick(bottleManager);
        }

        if (Input.GetKeyDown(KeyCode.C)) // Nhan phim 'C' de kiem tra
        {
            Debug.Log("Matched bottles: " + bottleManager.CountMatchedBottles());
        }
    }

 

}
