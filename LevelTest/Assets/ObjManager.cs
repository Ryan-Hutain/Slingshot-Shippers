using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public List<GameObject> nodes = new List<GameObject>();
    public List<GameObject> asteroids = new List<GameObject>();
    public List<GameObject> planets = new List<GameObject>();
    public List<GameObject> satellites = new List<GameObject>();
    public List<GameObject> miscs = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Lists of central bodies
        nodes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Node"));
        foreach (GameObject obj in nodes)
        {
            if (!nodes.Contains(obj))
            {
                nodes.Add(obj);
            }
        }
        asteroids = new List<GameObject>(GameObject.FindGameObjectsWithTag("Asteroid"));
        foreach (GameObject obj in asteroids)
        {
            if (!asteroids.Contains(obj))
            {
                asteroids.Add(obj);
            }
        }
        planets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Planet"));
        foreach (GameObject obj in planets)
        {
            if (!planets.Contains(obj))
            {
                planets.Add(obj);
            }
        }

        // Lists of orbiting bodies
        satellites = new List<GameObject>(GameObject.FindGameObjectsWithTag("Satellite"));
        foreach (GameObject obj in satellites)
        {
            if (!satellites.Contains(obj))
            {
                satellites.Add(obj);
            }
        }
        miscs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Misc"));
        foreach (GameObject obj in miscs)
        {
            if (!miscs.Contains(obj))
            {
                miscs.Add(obj);
            }
        }
    }
}
