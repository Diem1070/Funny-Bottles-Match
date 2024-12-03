using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuManager : MonoBehaviour
{
    public LevelData[] levels;

    public static int currentLevel;
    private GameManager gameManager;

    public void OnClickLevel(int levelNum)
    {
        currentLevel = levelNum - 1;

        // pass values to LevelManager via Singleton
        if (LevelManager.Instance != null )
        {
            LevelManager.Instance.SetLevelData(levels[currentLevel]);
            //Debug.Log("Current level data: " + LevelManager.Instance.currentLevel.NumberOfBottles);
            
        }
        else
        {
            Debug.LogError("LevelManager instance is null");
        }
        SceneManager.LoadScene("GamePlay");
        Debug.Log("Navigate to GamePlay successully");

    }


    public void OnClickBack()
    {
        this.gameObject.SetActive(false);
    }
    
}
