using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

// manage time count down
public class Timer : MonoBehaviour
{
    public TMP_Text timerText;              // Display time text on UI
    public Image slider;                    // circle bar
    public float timeLimit = 60f;           

    private float remainingTime;            // during counting down
    private bool startTimer;                // check if timer is running

    public bool inMinutes;                  // true -> mm:ss, false -> ss
    TimeSpan timeConvertor;                 // use TimeSpan to convert seconds to minutes

    [Space]
    public UnityEvent OnStart, OnComplete;  // events called when timer starts or ends

    float multiplierFactor;                 // ratio between remainingTime and slider


    // Initialize
    private void Start()
    {
        if (inMinutes)
        {
            timeConvertor = TimeSpan.FromSeconds(remainingTime);
            float minutes = timeConvertor.Minutes;
            float seconds = timeConvertor.Seconds;
            timerText.text = $"{minutes}:{seconds}";
        }
        else
        {
            timerText.text = Mathf.CeilToInt(remainingTime).ToString();
        }
        remainingTime = timeLimit;
        slider.fillAmount = remainingTime * multiplierFactor;
        startTimer = false;
    }


    // start counting down
    public void StartTimer()
    {
        // Initialize time: time = ...
        multiplierFactor = 1f / timeLimit;
        startTimer = true;
        slider.fillAmount = remainingTime * multiplierFactor;   // amount that takes 1s on slider

        // trigger event
        // how to use: display color or sound effect
        // this is how we call unity event...
        OnStart?.Invoke();
    }

    private void Update()
    {
        if (!startTimer) return;

        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;

            if (inMinutes)
            {
                timeConvertor = TimeSpan.FromSeconds(remainingTime);
                float minutes = timeConvertor.Minutes;
                float seconds = timeConvertor.Seconds;  
                timerText.text = $"{minutes}:{seconds}";
            }
            else
            {
                timerText.text = Mathf.CeilToInt(remainingTime).ToString();
            }

            slider.fillAmount = remainingTime * multiplierFactor;
        }
        else
        {
            // trigger event when the time over
            startTimer = false;
            OnComplete?.Invoke();
            // end game or change state
        }
    }

    public void StopTimer()
    {
        if (startTimer)
        {
            startTimer = false;
        }
    }

    public void RestartTimer()
    {
        remainingTime = timeLimit;
        if (inMinutes)
        {
            timeConvertor = TimeSpan.FromSeconds(remainingTime);
            float minutes = timeConvertor.Minutes;
            float seconds = timeConvertor.Seconds;
            timerText.text = $"{minutes}:{seconds}";
        }
        else
        {
            timerText.text = Mathf.CeilToInt(remainingTime).ToString();
        }
        slider.fillAmount = remainingTime * multiplierFactor;
    }
}
