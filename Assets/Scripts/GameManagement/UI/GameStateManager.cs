using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    private EGameState currentState;
    public UnityEvent OnGameStateChanged;

    public void ChangeState(EGameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case EGameState.Playing:
                GameUIManager.Instance.HidePausePanel();
                Time.timeScale = 1; // resume game
                break;

            case EGameState.Paused:
                GameUIManager.Instance.ShowPausePanel();
                Time.timeScale = 0;
                break;

            case EGameState.Success:
                GameUIManager.Instance.ShowSuccessPanel();
                Time.timeScale = 1;
                break;

            case EGameState.GameOver:
                GameUIManager.Instance.ShowGameOverPanel();
                Time.timeScale = 1;
                break;

        }
    }

}
