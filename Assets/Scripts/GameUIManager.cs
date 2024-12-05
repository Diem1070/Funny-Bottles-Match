using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    private static GameUIManager _instance;
    public static GameUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameUIManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameUIManager");
                    _instance = obj.AddComponent<GameUIManager>();
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

    public void Initialize()
    {
        HideAllPanels();
        GamePlayArea.SetActive(true);
    }

    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject successPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject GamePlayArea;
    [SerializeField] GameObject GameStatePanel;

    [SerializeField] TMP_Text stateText;

    // Set active for panel
    public void ShowPausePanel()
    {
        GamePlayArea.SetActive(false);
        pausePanel.SetActive(true);
    }

    // resume
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        GamePlayArea.SetActive(true);
    }

    // win
    public void ShowSuccessPanel()
    {
        //successPanel.SetActive(true);
        UpdateStateText(true);
        GameStatePanel.SetActive(true);
    }

    // lose
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }


    public void HideAllPanels()
    {
        pausePanel.SetActive(false );
        GamePlayArea.SetActive(false);
        successPanel.SetActive(false );
        GameStatePanel.SetActive(false);
    }

    // return home
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    // restart game
    public void Restart()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void UpdateStateText(bool isWin)
    {
        if (isWin && GameModeSelection.Instance.GetGameMode() == EGameMode.Level)
        {
            stateText.text = "Level Complete!";
        }
        else if (isWin)
        {
            stateText.text = "Success!";
        }
        else
        {
            stateText.text = "Game Over";
        }
    }

}
