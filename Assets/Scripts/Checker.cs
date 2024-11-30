using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    public int checkLimit;
    public TMP_Text checkText;
    public UnityEvent OnCheckPressed;   // event when click check

    private int remainingCheck;

    private void Start()
    {
        remainingCheck = checkLimit;
        if (checkLimit > 0)
        {
            checkText.text = $"Check ({remainingCheck.ToString()})";
        }
        else checkText.text = "Check";
    }

    public void OnClickCheck()
    {
        if (checkLimit == 0 ||  remainingCheck > 0)
        {
            if (remainingCheck > 0)
            {
                remainingCheck--;
                checkText.text = $"Check ({remainingCheck.ToString()})";
            }

            // call event when click check
            OnCheckPressed?.Invoke();
        }
    }
}
