using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMover : MonoBehaviour
{
    public float maxDist = 50f;
    public float speed = 10f;
    private bool hasCollided = false;
    private Rigidbody rb;
    private Vector3 initPos;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,speed,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Clamp(transform.position.y, initPos.y - maxDist, initPos.y + maxDist), 0f);
        if (!hasCollided) {
            distance = Vector3.Distance(transform.position, initPos);
            if (distance >= maxDist) {
                speed *= -1;
                rb.velocity = new Vector3(0,speed,0);
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        hasCollided = true;
    }
}
