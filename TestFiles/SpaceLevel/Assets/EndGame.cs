using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameManager status;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other) {
        status.isRunning = false;

        if (other.CompareTag("Player")) {
            rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0f,0f,0f);
        }
    }
}
