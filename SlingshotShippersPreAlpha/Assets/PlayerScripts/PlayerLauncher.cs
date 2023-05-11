using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public GameManager status;
    public GameObject cannonArea;
    public GameObject cannonBody;
    public GameObject arrowPrefab;
    public GameObject arrow;

    public Vector3 mousePosition;
    public Vector3 worldPosition;
    public Vector3 direction;
    public bool isAiming = false;
    public bool hasLaunched = false;
    public float arrowScaleFactor = 1.0f;
    public float maxArrowDistance = 40f;
    public float velocityScale = 1f;
    public Rigidbody rb;
    public Rigidbody rbCannon;
    private Vector3 mouseStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rbCannon = cannonBody.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rbCannon.constraints = RigidbodyConstraints.FreezePosition;

        Physics.IgnoreCollision(cannonBody.GetComponent<Collider>(), GetComponent<Collider>());
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
            if (isAiming && !hasLaunched) {
                float length = GetComponent<Renderer>().bounds.size.magnitude;
                arrow.transform.position = GetComponent<Renderer>().bounds.center + (Vector3.Normalize(direction) * (length / 4) * arrowScaleFactor * velocity);
                arrow.transform.right = direction;
                transform.right = new Vector3(direction.x, direction.y, 0);
                cannonBody.transform.right = direction;

                float distance = Mathf.Min(velocity, maxArrowDistance);
                arrow.transform.localScale = new Vector3(distance * arrowScaleFactor, 10f, 1f);
            }

            if (Input.GetMouseButtonDown(0) && !hasLaunched) {
                if (!isAiming) {
                    isAiming = true;

                    arrow = Instantiate(arrowPrefab, cannonArea.transform.position, Quaternion.identity);
                } else {
                    // Player clicks again to launch the object
                    isAiming = false;
                    hasLaunched = true;

                    if (GameObject.Find("Arrow(Clone)") != null) {
                        Destroy(arrow);
                    }
                    
                    rb.constraints = RigidbodyConstraints.None;
                    rb.AddForce(direction.normalized * (5e2f * velocity), ForceMode.Acceleration);
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
