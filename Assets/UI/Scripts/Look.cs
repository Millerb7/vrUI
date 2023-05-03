using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;  // get the main camera transform
    }

    private void LateUpdate()
    {
        // set the rotation of the UI panel to face the camera
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
        transform.rotation *= Quaternion.Euler(0, 90, 0); // Rotate 90 degrees around Y-axis
    }

}
