using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeHighScore : MonoBehaviour
{
    // Causes the high scores to display on any screen that is not the Game Win Screen
    void Start()
    {
        SaveData data = SaveManager.LoadScores();

        if (data == null)
        {
            data = SaveInstance.GetSave();
        }
        // Initializes data into active save instance
        SaveInstance.GetSave().Save(data);


        GetComponent<HighScoreDisplay>().UpdateText(SaveInstance.GetSave(), -1);
    }
}
