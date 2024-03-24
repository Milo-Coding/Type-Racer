using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    // sentance bank
    public SentanceBank sentanceBank = null;
    // sentance output for display
    public Text sentanceOutput = null;
    // full sentance for reference
    public Text sentanceDisplay = null;
    // remainder of sentance to be typed
    private string remainingSentance = string.Empty;
    // what has already been typed
    private string typedSentance = "";
    // current sentance we are typing
    private string currentSentance = string.Empty;
    
    // car
    public DriveCar myCar = null;
    // how far should the car move when you finish a letter
    private float ratio = -1f;
    public float wordsTyped = 0;

    // Start is called before the first frame update
    private void Start()
    {
        // set the current sentance
        SetCurrentSentance();
    }

    private void SetCurrentSentance()
    {
        // Get sentance from bank
        currentSentance = sentanceBank.GetRandomSentance();

        // determine the ratio of one word : words in sentance
        ratio = 10f / currentSentance.Split().Length;

        // at this point the whole sentance still has to be typed
        SetRemainingSentance(currentSentance);
        // and we haven't typed anything yet
        typedSentance = "";
        sentanceOutput.text = typedSentance;
        // display our sentance
        sentanceDisplay.text = currentSentance;
    }

    private void SetRemainingSentance(string newString)
    {
        // set the remaing sentance and update the display
        remainingSentance = newString;
    }
    // Update is called once per frame
    private void Update()
    {
        // check for an input each frame
        CheckInput();
    }

    private void CheckInput()
    {
        // whenever a key is pressed
        if(Input.anyKeyDown)
        {
            // record which letter(s)
            string keysPressed = Input.inputString;

            // if just one letter was pressed
            if(keysPressed.Length == 1)
            {
                // check if it was the next letter
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        // if the correct letter was typed
        if(IsCorrectLetter(typedLetter))
        {
            // record that we have typed it
            RecordLetter();
            // then remove that letter
            RemoveLetter();

            // if the typed letter is a spacebar our word is complete
            if (typedLetter == " ")
            {
                // move car and count word as typed
                myCar.MoveCar(ratio);
                wordsTyped += 1;
            }

            // check if the sentance is complete
            if(IsSentanceComplete())
            {
                // get a new sentance
                SetCurrentSentance();

                // move the car
                myCar.MoveCar(ratio);
                // and flip it
                myCar.flip();
                // and count the word
                wordsTyped += 1;
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        // check if the letter typed in is the next remaining letter in the sentance
        return remainingSentance.IndexOf(letter) == 0;
    }

    private void RecordLetter()
    {
        // add the first letter of our remaining sentance to what we have typed
        typedSentance += remainingSentance[0];
        // output that
        sentanceOutput.text = typedSentance;
    }

    private void RemoveLetter()
    {
        // remove the first letter from the remaing sentance
        string newString = remainingSentance.Remove(0,1);
        // update the display
        SetRemainingSentance(newString);
    }

    private bool IsSentanceComplete() {
        // check if the sentance is complete
        return remainingSentance.Length == 0;
    }

    public float getWordsTyped()
    {
        return wordsTyped;
    }
}
