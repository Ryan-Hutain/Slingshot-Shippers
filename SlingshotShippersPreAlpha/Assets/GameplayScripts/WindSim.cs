using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WindSim : MonoBehaviour
{
    public GameManager status;
    public Rigidbody rb;
    
    public float windSpeed;
    public Vector3 windDirection;
    public Vector3 wind;

    public GameObject windArrow;
    public TextMeshProUGUI windText;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        windText.text = $"{windSpeed.ToString()} mph";
        windArrow.transform.right = windDirection;

        windSpeed = 0.00256f * Mathf.Pow(windSpeed, 2);
        wind = Vector3.Normalize(windDirection) * windSpeed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status.isRunning) {
            rb.AddForce(wind, ForceMode.Force);
        }
    }
}
