using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public float velocityScale = 0.001f; // Scale the velocity by this amount
    public Rigidbody rb;
    public bool hasStarted = false;
    private bool isDragging = false;
    private Vector3 mouseStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isDragging = false;
        isDragging = DragDetector();
        if (!isDragging && !hasStarted && Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 0;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            Vector3 direction = worldPosition - transform.position;
            if (Vector3.Magnitude(direction) > 20) {
                direction = Vector3.Normalize(direction) * 20;
            }
            float velocity = direction.magnitude * velocityScale;
            rb.velocity = direction.normalized * velocity;
        }
    }

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
}
