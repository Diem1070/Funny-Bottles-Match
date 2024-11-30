using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSelection : MonoBehaviour
{
    private static GameModeSelection _instance;
    public static GameModeSelection Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameModeSelection>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameModeSelection");
                    _instance = obj.AddComponent<GameModeSelection>();
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

    private EGameMode currentGameMode;

    public void SetGameMode(EGameMode mode)
    {
        currentGameMode = mode;
    }

    public EGameMode GetGameMode()
    {
        return currentGameMode;
    }
}
