using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    public Dictionary<string, bool> levelStatus;
    [SerializeField] private int startIndex = 3; // Starts logging completion at tutorial

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        levelStatus = new Dictionary<string, bool>();

        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;     
        sceneCount -= startIndex;
        string[] scenes = new string[sceneCount];
        for(int i = 0; i < sceneCount; i++) {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i + startIndex));
        }
        foreach(string sceneName in scenes) {
            levelStatus.Add(sceneName, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string statusString = "";
        foreach (KeyValuePair<string, bool> kvp in levelStatus) {
            statusString += ($"Name = {kvp.Key}, Status = {kvp.Value} \n");
            //Debug.Log($"Name = {kvp.Key}, Status = {kvp.Value} \n");
        }
        Debug.Log(statusString);

        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "LevelsMenu") {
            Button[] levelButtons = FindObjectsOfType<Button>();
            foreach (Button button in levelButtons)
            {
                string buttonSceneName = button.name; // Assuming the button name matches the scene name
                bool isUnlocked = false;
                Debug.Log(buttonSceneName);
                if (levelStatus.ContainsKey(buttonSceneName))
                {
                    isUnlocked = levelStatus[buttonSceneName];
                }
                button.interactable = isUnlocked;
                levelButtons[0].interactable = true;
                if (button.CompareTag("MainMenu")) {
                    button.interactable = true;
                }
            }
        }
    }
}
