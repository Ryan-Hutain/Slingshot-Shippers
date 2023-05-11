using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("GameStarted"))
        {
            // Set the "GameStarted" player preference to 1 to indicate that the game has been started
            PlayerPrefs.SetInt("GameStarted", 1);

            // Load the main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MainMenu", 0);
    }
}
