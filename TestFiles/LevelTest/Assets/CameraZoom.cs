using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    public float zoomSpeed = 1000f;
    public float sensitivity = 100f;

    // Update is called once per frame
    void Update()
    {
        float targetZoom = cam.orthographicSize;
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);

        cam.orthographicSize = newSize;
    }
}