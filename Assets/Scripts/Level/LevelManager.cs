using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


// quan ly trang thai man choi va dieu kien thang thua
public class LevelManager : MonoBehaviour
{
    public LevelData currentLevel;
    public Timer timer;             // reference to Timer
    private int checkCount;         // Tracks how many times the player checked bottles

    
    void InitializeLevel()
    {
        // Load data for current level
        checkCount = 0;

        if (currentLevel.timerLimit > 0)
        {
            // timer.StartTimer(currentLevel.timerLimit);
        }

        Debug.Log("Level initialized: " + currentLevel.levelNumber);
    }

    public void OnCheckMatchedBottles(BottleManager bottleManager)
    {
        int matchedBottles = bottleManager.CountMatchedBottles();
        Debug.Log("Matched Bottles: " + matchedBottles);

        // Increment check count
        checkCount++;   

        // Victory condition
        if (matchedBottles == currentLevel.numberOfBottles)
        {
            Debug.Log("Level complete!");
            EndLevel(true);
        }

        else if (currentLevel.checkLimit > 0 && checkCount >= currentLevel.checkLimit)
        {
            Debug.Log("Check limit reached. Game over!");
            EndLevel(false);
        }
    }

    void EndLevel(bool isSuccess)
    {
        timer.StopTimer();
        // Add win/lose logic or move to next level
        Debug.Log(isSuccess ? "Level passed!" : "Level failed!");
    }
}
