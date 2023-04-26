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
            // Set the flag to indicate that the game has been started
            PlayerPrefs.SetInt("GameStarted", 1);

            // Load the main menu scene
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }
}
