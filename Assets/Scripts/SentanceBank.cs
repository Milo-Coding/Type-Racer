using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SentanceBank : MonoBehaviour
{
    // get the lines from the sentance bank text file
    private string[] sentances = {
        "A teacher's professional duties may extend beyond formal teaching. Outside of the classroom teachers may accompany students on field trips.",
        "Supervise study halls, help with the organization of school functions, and serve as supervisors for extracurricular activities.",
        "In some education systems, teachers may have responsibility for student discipline.",
        "One morning my friend and I were thinking about how we could plan our summer break away from school.",
        "Driving from our own state to several nearby states would help to expand our limited funds.",
        "Inviting six other friends to accompany us would lower our car expenses.",
        "Stopping at certain sites would also help us stretch our truly limited travel budget.",
        "Yesterday I engaged in an interesting and enlightening discussion about finances.",
        "I found it difficult to imagine that during my lifetime I might well earn at least one-half million dollars.",
        "It is also possible that I might spend as much as one-half million during the same period.",
        "The really difficult thing for me to do will be to save more of the half-million than I spend.",
        "Thinking about today's high cost of living makes this seem an impossible task for most.",
        "Last week I asked a friend to talk with me and a girl-friend about college. Our friend is the Dean of Women at a nearby college.",
        "The Dean and her staff spend much of their time talking to students who plan to go to college.",
        "The first thing she said was to work very hard each day in high school. Good grades are most important for being accepted.",
        "Being on time for classes and having a good view toward all phases of the school life are two other things to remember."
    };

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
