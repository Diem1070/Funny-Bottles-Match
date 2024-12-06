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
    }

    public void OnClickCustom()
    {
        customPanel.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void OnClickSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }
    public void QuickGame()
    {
        Application.Quit();
    }
}
