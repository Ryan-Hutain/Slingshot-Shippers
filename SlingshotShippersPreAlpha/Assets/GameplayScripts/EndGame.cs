using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameManager status;
    public Rigidbody rb;
    public GameObject winScreen;
    public GameObject loseScreen;

    public GameObject player;
    public int fuel;

    public Camera cam;
    CameraMove constraints;
    public float limit = 2f;
    float leftX;
    float rightX;
    float botY;
    float topY;

    private Vector3 initialPosition;
    public float distanceThreshold = 25f; // Adjust this value as needed
    public float duration = 10f; // Adjust this value as needed
    private float elapsedTime = 0f;
    private bool isStationary = false;

    public LevelData levelData;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        winScreen.SetActive(false);
        loseScreen.SetActive(false);

        constraints = cam.GetComponent<CameraMove>();
        leftX = constraints.minX * limit;
        rightX = constraints.maxX * limit;
        botY = constraints.minY * limit * 5f;
        topY = constraints.maxY * limit * 5f;

        initialPosition = player.transform.position;

        levelData = GameObject.FindGameObjectWithTag("LevelData").GetComponent<LevelData>();
    }

    void Update() {
        if (status.isRunning) {
            fuel = player.GetComponent<PlayerControls>().fuelLevel;

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= duration) {
                float distance = Vector3.Distance(initialPosition, player.transform.position);
                if (distance < distanceThreshold) {
                    isStationary = true;
                } else {
                    isStationary = false;
                }

                elapsedTime = 0f;
                initialPosition = player.transform.position;
            }


            if ((fuel == 0 && isStationary) || 
                (player.transform.position.x < leftX || player.transform.position.x > rightX || player.transform.position.y < botY || player.transform.position.y > topY)) {
                status.isRunning = false;

                loseScreen.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        status.isRunning = false;

        if (other.CompareTag("Player")) {
            rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0f,0f,0f);
            winScreen.SetActive(true);

            Dictionary<string, bool> levelStatus = levelData.levelStatus;
            string targetSceneName = SceneManager.GetActiveScene().name;
            if (levelStatus.ContainsKey(targetSceneName)) {
                levelStatus[targetSceneName] = true;
            }
        }
    }
}
