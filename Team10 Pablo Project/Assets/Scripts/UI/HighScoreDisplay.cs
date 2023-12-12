using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text1;
    [SerializeField]
    TextMeshProUGUI text2;
    [SerializeField]
    TextMeshProUGUI text3;
    [SerializeField]
    TextMeshProUGUI scoreText;

    // Updates scoreboard text and highlights the score of the index
    public void UpdateText(SaveData data, int currentScoreIndex)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Score.playerScore;
        }

        int[] scores = data.GetScores();

        SetHighScoreText(text1, scores[0], "1");
        SetHighScoreText(text2, scores[1], "2");
        SetHighScoreText(text3, scores[2], "3");

        // Highlights text of new score on scoreboard
        switch (currentScoreIndex)
        {
            case 0:
                text1.color = Color.magenta;
                break;
            case 1:
                text2.color = Color.magenta;
                break;
            case 2:
                text3.color = Color.magenta;
                break;
            default:
                break;
        }
                
    }
    
    void SetHighScoreText(TextMeshProUGUI text, int score, string numberLabel)
    {
        if (score > -1)
        {
            text.text = numberLabel + " - " + score.ToString();
        }
        else
        {
            text.text = "-";
        }
    }
}
