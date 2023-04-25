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
        velocity = new Vector3(-100f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasCrashed) {
            if (transform.position.x < -1500) {
                transform.position = new Vector3(1500f,transform.position.y,0);
            } else {
                transform.position += velocity * Time.deltaTime;
            }
        } else {
            velocity.y = -98.1f;
            transform.position += velocity * Time.deltaTime;
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
