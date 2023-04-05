using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = new Vector3(50f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -700) {
            transform.position = new Vector3(600f,transform.position.y,0);
        } else {
            transform.position += velocity;
        }
    }
}
