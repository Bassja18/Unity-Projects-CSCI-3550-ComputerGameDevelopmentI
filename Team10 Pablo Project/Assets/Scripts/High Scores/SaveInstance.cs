using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows retrieving the save data in an active game
public class SaveInstance
{
    const int HIGH_SCORE_COUNT = 3;

    static SaveData save = null;

    //Creates a new save if there isn't one already
    public static SaveData GetSave()
    {
        if (save == null)
        {
            int[] scores = new int[HIGH_SCORE_COUNT];
            for (int i = 0; i < HIGH_SCORE_COUNT; i++)
            {
                scores[i] = -99999;
            }
            save = new SaveData(scores);
        }
        return save;
    }
}
