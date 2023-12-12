using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public Text points;

    // Shows player's score on text
    public void Start()
    {
        if (points != null)
        {
            points.text = "Score: " + Score.playerScore.ToString();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Score.playerScore = 0;
    }
}
