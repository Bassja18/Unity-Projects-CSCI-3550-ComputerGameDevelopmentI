using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Change "SampleScene" to the name of our menu scene
    public void LoadMainMenu()
    {
        Score.playerScore = 0;
        SceneManager.LoadScene("MainMenuScene");
    }
}
