using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    // timer display text box
    public Text timerDisplay = null;
    // time on the timer
    private float timeValue = 60f;
    // Typer element
    public Typer Typer = null;

    // Update is called once per frame
    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else 
        {
            timeValue = 0f;
        }


        DisplayTime(timeValue);
    }

    private void DisplayTime(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);
        timerDisplay.text = string.Format("Time Remaining: {0:00}s", seconds);
    }

    public float GetWPM()
    {
        float numWords = Typer.getWordsTyped(); // get words
        float secondsElapsed = 60f - timeValue; // get time
        float minutesElapsed = secondsElapsed / 60f;
        float WPM = numWords / minutesElapsed;
        return WPM;
    }
}
