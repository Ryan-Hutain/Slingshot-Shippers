using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public GameObject sun;
        private Vector3 sunPos;
        public GameObject planet;
        private Vector3 planetPos;
        private float planetMass = 5.98e18;
        private float sunMass = 2e24;
        Vector3 planetVel = new Vector3(0,27.98e-3,0);

        Vector3 originalPos;
        Vector3 newPos;
        Vector3 planetAcc;
        Vector3 planetVel;
        Vector3 velocity;

        float G = 6.67e-11;

        private Vector3 grav_sim() {
            Vector3 sunPos = planet1.transform.position;
            Vector3 planetPos = planet2.transform.position;
            Vector3 pos_vec = sunPos - planetPos;

            Vector3 F = (G * sunMass * planetMass * pos_vec.Normalize()) / (Mathf.Pow(pos_vec.Magnitude(),2))
            
            return F;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dt = 50f;
        originalPos = planet.transform.position;
        planetAcc = F / sunMass;
        planetVel += planetAcc * dt;
        
        planet.transform.position += planetVel * dt;
        newPos = planet.transform.position;
        velocity = (newPos - originalPos) / dt;
    }
}