using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberSelector : MonoBehaviour
{
    public Text numberText;     // Text hien thi number of bottles
    public int minValue = 4;    // So chai nho nhat
    public int maxValue = 10;   // So chai lon nhat

    private int currentValue;


    // Start is called before the first frame update
    void Start()
    {
        currentValue = minValue;    // khoi tao
        UpdateNumberDisplay();
    }

    public void IncreaseValue()
    {
        if (currentValue < maxValue)
        {
            currentValue++;
            UpdateNumberDisplay();
            AudioManager._Instance.PlaySFX(AudioManager._Instance.buttonclick); //Play sfx
        }
    }

    public void DecreaseValue()
    {
        if (currentValue > minValue)
        {
            currentValue--;
            UpdateNumberDisplay();
            AudioManager._Instance.PlaySFX(AudioManager._Instance.buttonclick); //Play sfx
        }
    }

    private void UpdateNumberDisplay()
    {
        numberText.text = currentValue.ToString();
        // chuyen int sang string vi inspector chi nhan kieu string
    }

    public int GetCurrentNumber()
    {
        return currentValue;
    }
}
