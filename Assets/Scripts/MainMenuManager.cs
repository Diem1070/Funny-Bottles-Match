using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelMenu;
    public GameObject customPanel;
    public GameObject settingsPanel;
    
    public void OnClickChallenge()
    {
        GameModeSelection.Instance.SetGameMode(EGameMode.Level);
        levelMenu.gameObject.SetActive(true);
    }

    public void OnClickCustom()
    {
        GameModeSelection.Instance.SetGameMode(EGameMode.Custom);
        customPanel.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void OnClickSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }
}
