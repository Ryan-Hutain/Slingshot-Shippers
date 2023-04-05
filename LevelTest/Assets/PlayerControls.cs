using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    public GameManager status;

    public GameObject obj;
    public Rigidbody rb;
    public Vector2 speed = new Vector2(50, 50);
    public Vector3 movement;
    public float moveSpeed = 10f;
    public float inputX;
    public float inputY;

    public int fuelLevel = 100;
    public TextMeshProUGUI fuelText;

    void Start() {
        status = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = obj.GetComponent<Rigidbody>();
        fuelText.text = $"Fuel Level: {fuelLevel.ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
        if (status.isRunning == true && fuelLevel > 0) {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");

            movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

            if (inputX != 0 || inputY != 0) {
                fuelLevel--;
                fuelText.text = $"Fuel Level: {fuelLevel.ToString()}";

                rb.AddForce(Vector3.Normalize(movement) * moveSpeed, ForceMode.Acceleration);
            }
        }
    }
}