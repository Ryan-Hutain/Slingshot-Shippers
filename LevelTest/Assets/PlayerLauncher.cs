using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public GameManager status;
    public GameObject cannon;
    public GameObject arrowPrefab;
    public GameObject arrow;

    public Vector3 mousePosition;
    public Vector3 worldPosition;
    public Vector3 direction;
    public bool isAiming = false;
    public float arrowScaleFactor = 1.0f;
    public float maxArrowDistance = 20f;
    public float velocityScale = 0.001f;
    public Rigidbody rb;
    private Vector3 mouseStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        direction = worldPosition - transform.position;
        if (Vector3.Magnitude(direction) > maxArrowDistance) {
            direction = Vector3.Normalize(direction) * maxArrowDistance;
        }
        float velocity = direction.magnitude * velocityScale;

        if (status.isRunning == true) {
            if (isAiming) {
                float length = GetComponent<Renderer>().bounds.size.magnitude;
                arrow.transform.position = GetComponent<Renderer>().bounds.center + (Vector3.Normalize(direction) * (length / 4) * arrowScaleFactor * velocity);
                arrow.transform.right = direction;

                float distance = Mathf.Min(velocity, maxArrowDistance);
                arrow.transform.localScale = new Vector3(distance * arrowScaleFactor, 1f, 1f);
            }

            if (Input.GetMouseButtonDown(0)) {
                if (!isAiming) {
                    isAiming = true;

                    arrow = Instantiate(arrowPrefab, cannon.transform.position, Quaternion.identity);
                } else {
                    // Player clicks again to launch the object
                    isAiming = false;

                    if (GameObject.Find("Arrow(Clone)") != null) {
                        Destroy(arrow);
                    }

                    rb.velocity = direction.normalized * velocity;
                }
            }
        }
    }

    /*
    private bool DragDetector() {
        if (Input.GetMouseButtonDown(0)) {
            mouseStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            return false;
        }

        if (Input.GetMouseButton(0) && (Input.mousePosition - mouseStartPosition).magnitude > 5) {
            return true;
        }
        return false;
    }
    */
}
