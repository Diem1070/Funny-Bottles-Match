using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuManager : MonoBehaviour
{
    public LevelData[] levels;

    public void StartLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levels.Length) return;

        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.currentLevel = levels[levelIndex];

        Debug.Log("Starting level " + levels[levelIndex].levelNumber);
        // Load GamePlay scene or initialize the level
    }


    public void OnClickBack()
    {
        this.gameObject.SetActive(false);
    }

    
}
