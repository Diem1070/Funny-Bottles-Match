using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject customPanel;
    [SerializeField] GameObject settingsPanel;
    
    public void OnClickChallenge()
    {
        levelMenu.gameObject.SetActive(true);
        AudioManager._Instance.PlaySFX(AudioManager._Instance.buttonclick); //Play buttonclick sfx
    }

    public void OnClickCustom()
    {
        customPanel.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        AudioManager._Instance.PlaySFX(AudioManager._Instance.buttonclick); //Play sfx
    }

    public void OnClickSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
        AudioManager._Instance.PlaySFX(AudioManager._Instance.buttonclick); //Play sfx
    }
    public void QuickGame()
    {
        Application.Quit();
    }
}
