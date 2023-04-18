using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity;
    bool hasCrashed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = new Vector3(-1f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasCrashed) {
            if (transform.position.x < -700) {
                transform.position = new Vector3(600f,transform.position.y,0);
            } else {
                transform.position += velocity;
            }
        } else {
            velocity.y = -0.981f;
            transform.position += velocity;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Node")) {
            if (!hasCrashed) {
            transform.Rotate(0,0,30);
            }
            hasCrashed = true;
        }
    }
}
