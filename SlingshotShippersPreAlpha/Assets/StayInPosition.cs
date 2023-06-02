using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInPosition : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;

    void Update()
    {
        obj1.GetComponent<Rigidbody2D>().velocity = obj2.GetComponent<Rigidbody>().velocity;
        obj2.transform.position = obj1.transform.position;
    }
}
