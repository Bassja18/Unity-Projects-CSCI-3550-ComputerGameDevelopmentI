using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class holds actual values for the save data
[System.Serializable]
public class SaveData
{
    private int[] scores;

    public SaveData(int[] scores)
    {
        this.scores = new int[3];
        for (int i = 0; i < scores.Length; i++)
        {
            this.scores[i] = scores[i];
        }
    }

    // Adds scores to data
    public void Save(int[] scores)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            this.scores[i] = scores[i];
        }
    }
    // Copies values from one Save Data to this one
    public void Save(SaveData saveData)
    {
        for (int i = 0; i < saveData.scores.Length; i++)
        {
            this.scores[i] = saveData.scores[i];
        }
    }

    public int[] GetScores()
    {
        return scores;
    }

    // Adds a score into the high scores. Returns the index that the score was placed, -1 if it did not make it
    public int AddScore(int score)
    {
        // Target index is where the score ended up
        int targetIndex = -1;
        int nextScore = 0;
        bool pushing = false;
        for (int i = 0; i < scores.Length; i++)
        {
            if (pushing)
            {
                int temp = scores[i];
                scores[i] = nextScore;
                nextScore = temp;
            }
            else if (score > scores[i])
            {
                nextScore = scores[i];
                scores[i] = score;
                pushing = true;
                targetIndex = i;
            }
        }
        return targetIndex;
    }
}
