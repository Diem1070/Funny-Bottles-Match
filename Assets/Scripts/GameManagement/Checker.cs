using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    private int checkLimit = 0;         // default
    [SerializeField] TMP_Text checkText;
    public UnityEvent OnCheck;   // event when click check

    private int remainingCheck;
    private ECheckMode checkMode = ECheckMode.ButtonCheck;      // default

    public void SetCheckLimit(int checkLimit)
    {
        this.checkLimit = checkLimit;
    }

    public void SetCheckMode(ECheckMode checkMode)
    {
        this.checkMode = checkMode;
        UpdateCheckText();
    }

    public ECheckMode GetCheckMode()
    {
        return checkMode;
    }

    private void Start()
    {
        remainingCheck = checkLimit;
        UpdateCheckText();
    }

    public void OnClickCheck()
    {
        if (checkMode == ECheckMode.ButtonCheck && (checkLimit == 0 ||  remainingCheck > 0))
        {
            if (remainingCheck > 0)
            {
                remainingCheck--;
            }
            UpdateCheckText();
            // call event when click check
            OnCheck?.Invoke();
        }
    }

    public void AutoCheck()
    {
        if (checkMode == ECheckMode.AutoCheck && (checkLimit == 0 || remainingCheck > 0))
        {
            if (remainingCheck > 0)
            {
                remainingCheck--;
            }
            UpdateCheckText();
            OnCheck?.Invoke();
        }
    }

    private void UpdateCheckText()
    {
        if (checkMode == ECheckMode.ButtonCheck)
        {
            if (checkLimit > 0)
            {
                checkText.text = $"Check ({remainingCheck})";
            }
            else
            {
                checkText.text = "Check";
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
