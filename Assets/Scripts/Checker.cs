using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Checker : MonoBehaviour
{
    public int checkLimit;
    public TMP_Text checkText;
    

    private int remainingCheck;
    private bool isCheck;

    private void Start()
    {
        remainingCheck = checkLimit;
        checkText.text = $"Check ({remainingCheck.ToString()})";
        isCheck = true;
    }

    public void OnClickCheck()
    {
        if (remainingCheck > 0)
        {
            remainingCheck--;
            checkText.text = $"Check ({remainingCheck.ToString()})";
        }
        else
        {
            isCheck = false;
        }
    }
}
