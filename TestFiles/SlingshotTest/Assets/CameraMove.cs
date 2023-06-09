using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed;

    public TimeManip timeManip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");

            Vector3 newPosition = transform.position - new Vector3(horizontalInput, verticalInput, 0) * cameraSpeed * Time.deltaTime * (1/timeManip.timeScale);
            transform.position = newPosition;
        }
    }
}
