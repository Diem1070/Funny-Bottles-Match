using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject GamePlayArea;
    public void Pause()
    {
        pausePanel.SetActive(true);
        GamePlayArea.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        pausePanel.SetActive(false);    
        GamePlayArea.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
