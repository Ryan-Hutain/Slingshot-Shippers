using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Panning")]
    public float cameraSpeed;
    public float smoothing;
    public Vector3 targetPosition;
    public float positionX;
    public float positionY; 
    public TimeManip timeManip;

    public Vector3 canvasInitPos;
    float canvasH;
    float canvasW;

    [Header("Zooming")]
    public Camera cam;
    public float zoomSpeed;
    public float targetZoom;
    public float sensitivity;

    void Start()
    {
        targetPosition = transform.position;
        targetZoom = cam.orthographicSize;

        //Canvas canvas = FindObjectOfType<Canvas>();
        GameObject canvas = GameObject.Find("Canvas");
        canvasInitPos = canvas.GetComponent<RectTransform>().position;
        canvasH = canvas.GetComponent<RectTransform>().rect.height;
        canvasW = canvas.GetComponent<RectTransform>().rect.width;
    }
    void Update()
    {
        // Panning
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, canvasInitPos.x - (canvasW / 2), canvasInitPos.x + (canvasW / 2)), 
                                         Mathf.Clamp(transform.position.y, canvasInitPos.y - (canvasH / 2), canvasInitPos.y + (canvasH / 2)), 
                                         -10);

        if (Input.GetMouseButton(0)) {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");

            targetPosition = targetPosition - new Vector3(horizontalInput, verticalInput, 0) * cameraSpeed * Time.deltaTime * (1/timeManip.timeScale);
            positionX = transform.position.x;
            positionY = transform.position.y;
            // transform.position = targetPosition;
            positionX = Mathf.Lerp(positionX, targetPosition.x, Time.deltaTime * smoothing);
            positionY = Mathf.Lerp(positionY, targetPosition.y, Time.deltaTime * smoothing);
            transform.position = new Vector3(positionX, positionY, -10);
        }

        // Zooming
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, 1, 500);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
    }
}
