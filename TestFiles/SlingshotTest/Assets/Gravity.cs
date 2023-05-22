using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject body1;
    public Rigidbody rb1;
    public Vector3 body1Pos;
    public GameObject body2;
    public Rigidbody rb2;
    public Vector3 body2Pos;

    public Vector3 pos_vec;
    public Vector3 F;

    public float G = 6.67e-11f;

    // Start is called before the first frame update
    void Start()
    {
        rb1 = body1.GetComponent<Rigidbody>();
        rb2 = body2.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        body1Pos = body1.transform.position;
        body2Pos = body2.transform.position;
        pos_vec = body1Pos - body2Pos;
        if (Vector3.Magnitude(pos_vec) <= 125) {
            F = (G * rb1.mass * rb2.mass * Vector3.Normalize(pos_vec)) / (Mathf.Pow(Vector3.Magnitude(pos_vec),2));
        } else {
            F = new Vector3(0f,0f,0f);
        }

        rb1.AddForce(-F, ForceMode.Acceleration);
        rb2.AddForce(F, ForceMode.Acceleration);
    }
}