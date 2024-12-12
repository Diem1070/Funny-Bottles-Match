using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static GameSettings _instance;
    public static GameSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameSettings>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameSettings");
                    _instance = obj.AddComponent<GameSettings>();
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


    private int numberOfBottles;
    public void SetNumberOfBottles(int number)
    {
        Debug.Log("Setting number of bottles to: " + number);
        numberOfBottles = number;
    }

    public int GetNumberOfBottles()
    {
        Debug.Log("Getting number of bottles: " + numberOfBottles);
        return numberOfBottles;
    }
    
}
