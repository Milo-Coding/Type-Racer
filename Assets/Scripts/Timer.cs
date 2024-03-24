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

    // this can also update sentance display to let the player know when the game is over
    public Text sentanceDisplay = null;

    // Update is called once per frame
    private void Update()
    {
        if (timeValue > 0)
        {
            // time ticks
            timeValue -= Time.deltaTime;
            // recalculate wpm
            DisplayWPM();
            // make sure text is white
            sentanceDisplay.color = Color.white;
        }
        else 
        {
            // timer stops at 0
            timeValue = 0f;
            // make sure text is red
            sentanceDisplay.color = Color.red;
        }

        DisplayTime(timeValue);
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
