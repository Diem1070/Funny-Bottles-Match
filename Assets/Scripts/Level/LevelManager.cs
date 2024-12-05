using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

// Instance duy nhat duoc truy cap tu moi noi
// nhan thong tin man choi tu LevelMenuManager va pass gia tri cho GameManager de khoi tao chai
public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("LevelManager");
                    _instance = obj.AddComponent<LevelManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private LevelData currentLevel;

    public void SetLevelData(LevelData levelData)
    {
        currentLevel = levelData;
        Debug.Log("LevelManager: Setting level data...");
        Debug.Log("Level number: " + currentLevel.LevelNumber);
        Debug.Log("Number of bottles: " + currentLevel.NumberOfBottles);
        
    }

    public LevelData GetLevelData()
    {
        return currentLevel;
    }
    
}
