using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject body1;
    public float body1Mass = 1e+15f;
    public Vector3 body1Pos;
    public Vector3 body1Vel = new Vector3(0f,0f,0f);
    public Vector3 body1Acc = new Vector3(0f,0f,0f);
    public GameObject body2;
    public float body2Mass = 1000000f;
    public Vector3 body2Pos;
    public Vector3 body2Vel = new Vector3(0f,0f,0f);
    public Vector3 body2Acc = new Vector3(0f,0f,0f);

    public PlayerControls controls;
    public float moveSpeed = 50f;

    public Vector3 pos_vec;
    public Vector3 F;

    public float G = 6.67e-11f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        body1Pos = body1.transform.position;
        body2Pos = body2.transform.position;
        pos_vec = body1Pos - body2Pos;
        if (Vector3.Magnitude(pos_vec) <= 125) {
            F = (G * body1Mass * body2Mass * Vector3.Normalize(pos_vec)) / (Mathf.Pow(Vector3.Magnitude(pos_vec),2));
        } else {
            F = new Vector3(0f,0f,0f);
        }

        float dt = 0.01f;
        //body1Acc = -F / body1Mass;
        body2Acc = F / body2Mass;
        //body1Vel += body1Acc * dt;

        if ((body2.GetComponent("PlayerControls") as PlayerControls) != null) {
            PlayerControls controls = body2.GetComponent<PlayerControls>();
            if (controls.inputX != 0 || controls.inputY != 0) {
                body2Acc += Vector3.Normalize(controls.movement) * moveSpeed;
                //body2Vel = Vector3.Normalize(controls.movement) * Vector3.Magnitude(body2Vel);
            }
        }
        body2Vel += body2Acc * dt;
        
        //body1.transform.position += body1Vel * dt;
        body2.transform.position += body2Vel * dt;
    }

    private void OnTriggerEnter(Collider other) { // Simulates normal force between colliding objects
        body2Acc -= Vector3.Project(pos_vec, body2Acc);
        body2Vel -= Vector3.Project(pos_vec, body2Vel);
    }
}