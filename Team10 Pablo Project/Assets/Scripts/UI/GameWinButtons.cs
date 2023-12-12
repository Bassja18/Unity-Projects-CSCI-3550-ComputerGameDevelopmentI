using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinButtons : MonoBehaviour
{
    public void PlayAgainPressed()
    {
        SceneManager.LoadScene("SampleScene");
        Score.playerScore = 0;
    }
    public void MainMenuPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
        Score.playerScore = 0;
    }
}
