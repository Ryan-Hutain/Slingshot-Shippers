using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject obj;
    public Rigidbody rb;
    public Vector2 speed = new Vector2(50, 50);
    public Vector3 movement;
    public float moveSpeed = 10f;
    public float inputX;
    public float inputY;

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        rb = obj.GetComponent<Rigidbody>();
        if (inputX != 0 || inputY != 0) {
            rb.AddForce(Vector3.Normalize(movement) * moveSpeed, ForceMode.Acceleration);
        }
    }
}