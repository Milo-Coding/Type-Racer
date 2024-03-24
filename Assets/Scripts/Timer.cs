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
    // wpm display text box
    public Text WPMDisplay = null;
    // time on the timer
    private float timeValue = 60f;
    // Typer element
    public Typer Typer = null;

    // words per minute
    float WPM = 0;

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
        DisplayWPM();
    }

    private void DisplayTime(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);
        timerDisplay.text = string.Format("Time Remaining: {0:00}s", seconds);
    }

    private void DisplayWPM()
    {
        float numWords = Typer.getWordsTyped(); // get words
        float secondsElapsed = 60f - timeValue; // get time
        float minutesElapsed = secondsElapsed / 60f; // get minures
        WPM = numWords / minutesElapsed; // get wpm
        WPMDisplay.text = string.Format("WPM: {0:00}", WPM);
    }
}
