using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float distance = .75f;   // distance between camera and UI panel
    public float height = .2f;       // height of UI panel relative to camera

    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;  // get the main camera transform

        Vector3 panelPos = cameraTransform.position + cameraTransform.transform.forward * distance;
        transform.position = panelPos;

    }

    private void LateUpdate()
    {
        // set the position and rotation of the UI panel based on the camera's transform
        transform.position = cameraTransform.position + cameraTransform.forward * distance + Vector3.up * height;
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
        transform.rotation *= Quaternion.Euler(0, 90, 0); // Rotate 90 degrees around Y-axis
    }
}
