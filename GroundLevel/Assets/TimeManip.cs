using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManip : MonoBehaviour
{
    public float timeScale;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            Time.timeScale = timeScale * 2;
        } else {
            Time.timeScale = timeScale;
        }
    }
}
