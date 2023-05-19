using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject ObjManager;
    public ObjManager objList;
    public GameManager status;

    public Rigidbody rb1;
    public Vector3 body1Pos;
    public Rigidbody rb2;
    public Vector3 body2Pos;

    public bool circleOrbit;
    public bool hasCollided = false;
    public float rotationSpeed = 10f;

    public Vector3 pos_vec;
    public float r;
    public float grav_rad;
    public Vector3 F;
    public float v_circle;

    public float G = 6.67e-11f;


    // Start is called before the first frame update
    void Start()
    {
        objList = GameObject.FindGameObjectWithTag("ObjManager").GetComponent<ObjManager>();
        status = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject node in objList.nodes) {
            foreach (GameObject satellite in objList.satellites) {
                if (node != null && satellite != null) {
                    GravCalc(node, satellite, true);
                }
            }
            foreach (GameObject misc in objList.miscs) {
                if (node != null && misc != null) {
                    GravCalc(node, misc, false);
                }
            }
        }
        foreach (GameObject asteroid in objList.asteroids) {
            foreach (GameObject satellite in objList.satellites) {
                if (asteroid != null && satellite != null) {
                    GravCalc(asteroid, satellite, true);
                }
            }
            foreach (GameObject misc in objList.miscs) {
                if (asteroid != null && misc != null) {
                    GravCalc(asteroid, misc, false);
                }
            }
        }
        foreach (GameObject planet in objList.planets) {
            foreach (GameObject satellite in objList.satellites) {
                if (planet != null && satellite != null) {
                    GravCalc(planet, satellite, true);
                }
            }
            foreach (GameObject misc in objList.miscs) {
                if (planet != null && misc != null) {
                    GravCalc(planet, misc, false);
                }
            }
        }
    }

    public void GravCalc(GameObject body1, GameObject body2, bool circleOrbit) {
        if (status.isRunning) {
            rb1 = body1.GetComponent<Rigidbody>();
            rb2 = body2.GetComponent<Rigidbody>();

            switch (body1.tag) {
                case "Node":
                    grav_rad = 25;
                    break;
                case "Asteroid":
                    grav_rad = 50;
                    break;
                case "Planet":
                    grav_rad = 250;
                    break;
                default:
                    grav_rad = 0;
                    break;
            }

            body1Pos = body1.transform.position;
            body2Pos = body2.transform.position;
            pos_vec = body1Pos - body2Pos;
            r = Vector3.Magnitude(pos_vec);
            
            if (Vector3.Magnitude(pos_vec) <= grav_rad) {
                if (circleOrbit && !hasCollided) {
                    Orbit(body2);
                } else {
                    F = (G * rb1.mass * rb2.mass * Vector3.Normalize(pos_vec));// / (Mathf.Pow(r,2f));
                }
            } else {
                F = new Vector3(0f,0f,0f);
            }

            rb1.AddForce(-F, ForceMode.Acceleration);
            rb2.AddForce(F, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision collision) {
        hasCollided = true;
    }

    void Orbit(GameObject body2) {
        v_circle = Mathf.Sqrt((G * rb1.mass) / r) * (r * 5);
        rb2.velocity = v_circle * Vector3.Normalize(new Vector3(-pos_vec.y, pos_vec.x, 0));

        float T = Mathf.Sqrt(Mathf.Pow(r,3) / (G * rb1.mass));
        body2.transform.RotateAround(body1Pos, new Vector3(0,0,1), 360 / (-T * Time.deltaTime * 100));

        //Debug.Log($"Time: {Time.realtimeSinceStartup}\nDistance: {r}");
    }
}