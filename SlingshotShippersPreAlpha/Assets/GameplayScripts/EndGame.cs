using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update() {
        fuel = player.GetComponent<PlayerControls>().fuelLevel;

        if ((fuel == 0 && player.GetComponent<Rigidbody>().velocity.magnitude <= 1f) || 
            (player.transform.position.x < leftX || player.transform.position.x > rightX || player.transform.position.y < botY || player.transform.position.y > topY)) {
            status.isRunning = false;

            loseScreen.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) {
        status.isRunning = false;

        if (other.CompareTag("Player")) {
            rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0f,0f,0f);
            winScreen.SetActive(true);
        }
    }
}
