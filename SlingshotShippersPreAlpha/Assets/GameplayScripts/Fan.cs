using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private GameObject fanTop;
    public float rotation;
    private Vector3 fanDirection;
    public float fanSpeed;
    private Rigidbody rb;
    public Vector3 fanWind;
    private Vector3 fanBlowDir;

    // Start is called before the first frame update
    void Start()
    {
        fanTop = transform.parent.gameObject;
        fanDirection = new Vector3(0f, 0f, rotation);
        Quaternion fanDir = Quaternion.Euler(fanDirection);
        fanTop.transform.rotation = fanDir;

        fanTop.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //fanSpeed = 0.00256f * Mathf.Pow(fanSpeed, 2);
            float distance = Vector3.Distance(fanTop.transform.position, other.transform.position);
            fanBlowDir = transform.up;
            fanWind = Vector3.Normalize(fanBlowDir) * (fanSpeed / distance);

            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(fanWind, ForceMode.Force);
        }
    }
}
