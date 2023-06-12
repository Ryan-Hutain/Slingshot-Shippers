using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    public float strength;

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Rigidbody>() != null) {
            other.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(transform.up) * strength, ForceMode.Force);
        }
    }
}
