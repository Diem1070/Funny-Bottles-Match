using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameStateManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameStateManager");
                    _instance = obj.AddComponent<GameStateManager>();
                    DontDestroyOnLoad(obj);
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
            //DontDestroyOnLoad(gameObject);      // use this when it's not a child
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject gameSuccessPanel;
    public GameObject gameOverPanel;


    public void ShowSuccessPanel()
    {
        
        gameSuccessPanel.SetActive(true);
    }

    public void ShowOverPanel()
    { 
        gameOverPanel.SetActive(true);
    }

}
