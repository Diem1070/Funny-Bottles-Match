using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // de dung LoadScene

public class CustomController : MonoBehaviour
{
    public NumberSelector numberSelector;   // tham chieu den NumberSelector

    private void Start()
    {
        if (numberSelector == null)
        {
            Debug.LogError("NumberSelector is not assigned!");
        }
        else
        {
            Debug.Log("NumberSelector is assigned.");
        }
    }
    public void OnPlayButtonPressed()
    {
        GameModeSelection.Instance.SetGameMode(EGameMode.Custom);
        Debug.Log(numberSelector.GetCurrentNumber());
        // truyen number of bottles vao GameSettings
        GameSettings.Instance.SetNumberOfBottles(numberSelector.GetCurrentNumber());

        // navigate to GamePlay
        SceneManager.LoadScene("GamePlay");
        AudioManager._Instance.PlaySFX(AudioManager._Instance.buttonclick); //Play sfx
    }
    
}
