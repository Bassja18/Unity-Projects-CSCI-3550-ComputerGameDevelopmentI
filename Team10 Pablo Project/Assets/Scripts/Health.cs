using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public void Damage()
    {
        // There is no health, it is a one-hit kill that takes you to the game over screen
        SceneManager.LoadScene("GameOverScene");
    }
}
