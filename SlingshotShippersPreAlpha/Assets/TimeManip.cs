using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManip : MonoBehaviour
{
    public float timeScale;
    public float timeAccel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")) {
            Time.timeScale = timeScale * timeAccel;
        } else {
            Time.timeScale = timeScale;
        }
    }
}
