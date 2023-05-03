using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public enum SceneEnum {
        None = -1, 
        MainMenu = 0,
        Levels = 1,
        Settings = 2,
        Tutorial = 3,
        Level1 = 4,
        Level2 = 5
    }

    public SceneEnum targetScene;

    public void SwitchScene() {
        SceneManager.LoadSceneAsync((int)targetScene, LoadSceneMode.Single);
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void LevelSettings() {
        SceneManager.LoadSceneAsync((int)targetScene, LoadSceneMode.Additive);
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene) {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        SceneManager.LoadSceneAsync((int)targetScene, LoadSceneMode.Single);
    }

    public void QuitGame() {
        PlayerPrefs.SetInt("GameStarted", 0);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}