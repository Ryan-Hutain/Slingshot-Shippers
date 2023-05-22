using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjParams : MonoBehaviour
{
    public GameObject obj;
    public float mass;
    public Vector3 velocity;
    public Vector3 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.mass = mass;
        rb.velocity = velocity;
        rb.AddForce(acceleration, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
