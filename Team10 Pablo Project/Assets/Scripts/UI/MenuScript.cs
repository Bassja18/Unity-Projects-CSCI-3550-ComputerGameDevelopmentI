using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   public void PlayGame()
    {
        // Change "SampleScene" to the name of our game scene
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
