/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOrbit : MonoBehaviour
{
    public Gravity grav;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        grav = obj.GetComponent<Gravity>();

        grav.rb2.velocity = Mathf.Sqrt((grav.G * grav.rb1.mass) / Vector3.Magnitude(grav.pos_vec)) * Vector3.Normalize(new Vector3(grav.pos_vec.y, grav.pos_vec.x, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/