using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public TextMeshProUGUI symbol;
    public bool isPaused = false;
    private string pause = "||";
    private string play = "\u25BA";

    void Start() {
        pauseMenu.SetActive(false);
        symbol.text = pause;
    }

    public void TogglePause() {
        pauseMenu.SetActive(true);
        symbol.text = play;
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void TogglePlay() {
        pauseMenu.SetActive(false);
        symbol.text = pause;
        isPaused = false;
        Time.timeScale = 1f;
    }
}
