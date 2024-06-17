using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene (replace "GameScene" with your actual game scene name)
        SceneManager.LoadScene("GAME");
    }

    public void QuitGame()
    {
        // Quit the application (only works in builds, not in the Unity Editor)
        Application.Quit();
    }
}
