using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollingSpeed = 1f;
    private float cameraRight;

    void Start() {
        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        cameraRight = mainCamera.transform.position.x + cameraWidth / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = scrollingSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * movement);

        if (transform.position.x >= cameraRight * 2)
        {
            // Calculate the starting position on the left side
            Vector3 resetPosition = new Vector3(-cameraRight, transform.position.y, transform.position.z);
            transform.position = resetPosition;
        }

    }
}
