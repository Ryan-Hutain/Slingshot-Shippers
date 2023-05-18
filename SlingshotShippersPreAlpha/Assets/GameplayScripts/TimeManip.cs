using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManip : MonoBehaviour
{
    public float timeScale;
    public float timeAccel = 2;
    public GameObject pauseButton;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = pauseButton.GetComponent<Pause>().isPaused;
        Time.timeScale = timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = pauseButton.GetComponent<Pause>().isPaused;
        if (!isPaused) {
            if (Input.GetKey("space")) {
                Time.timeScale = timeScale * timeAccel;
            } else {
                Time.timeScale = timeScale;
            }
        } else {
            Time.timeScale = 0.0f;
        }
    }
}
