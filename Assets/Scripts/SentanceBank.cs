using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SentanceBank : MonoBehaviour
{
    // get the lines from the sentance bank text file
    private string[] sentances = System.IO.File.ReadAllLines(@"./Assets/SentanceBank.txt");

    // track our current sentance
    private string currentSentance = string.Empty;

    private void Awake()
    {
        // get a sentance to start
        currentSentance = GetRandomSentance();
    }

    public string GetRandomSentance()
    {
        // get a random sentance from the word bank
        int i = Random.Range(0, sentances.Length);

        // return our sentance
        return sentances[i];
    }
}
