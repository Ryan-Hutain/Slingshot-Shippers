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
        GroundLevel1 = 4,
        GroundLevel2 = 5,
        GroundLevel3 = 6,
        GroundLevel4 = 7,
        SpaceLevel1 = 8,
        SpaceLevel2 = 9,
        SpaceLevel3 = 10,
        SpaceLevel4 = 11
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

    public void Restart() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentLevel, LoadSceneMode.Single);
    }

    public void NextLevel() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentLevel + 1, LoadSceneMode.Single);
    }

    public void QuitGame() {
        PlayerPrefs.SetInt("GameStarted", 0);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}