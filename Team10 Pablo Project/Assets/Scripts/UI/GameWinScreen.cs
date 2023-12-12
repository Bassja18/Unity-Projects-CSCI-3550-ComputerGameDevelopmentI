using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinScreen : MonoBehaviour
{
    [SerializeField]
    HighScoreDisplay scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        int currentScoreIndex = -1;
        SaveData data = SaveManager.LoadScores();

        if (data == null)
        {
            data = SaveInstance.GetSave();
        }

        int[] scores = data.GetScores();

        currentScoreIndex = data.AddScore(Score.playerScore);
        SaveManager.SaveScores(data);

        scoreDisplay.UpdateText(data, currentScoreIndex);
    }
}
