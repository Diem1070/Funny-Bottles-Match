using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        successPanel.SetActive(true);
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

}
