using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastRay : MonoBehaviour
{
    public OVRCameraRig cameraRig;
    public float detectionThreshold = 0.5f;
    public string tagToDetect = "UIPanel";

    private GameObject currentObject;
    private UIPanel currentUIPanel;

    private void Update()
    {
        RaycastHit[] hits = Physics.RaycastAll(cameraRig.centerEyeAnchor.position, cameraRig.centerEyeAnchor.forward);

        float closestDistance = Mathf.Infinity;
        GameObject closestObject = null;
        UIPanel closestUIPanel = null;

        foreach (RaycastHit hit in hits)
        {
            Debug.Log(hit);
            if (hit.collider.CompareTag(tagToDetect))
            {
                Debug.Log("collide");
                float distance = Vector3.Distance(cameraRig.centerEyeAnchor.position, hit.point);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = hit.collider.gameObject;
                    closestUIPanel = closestObject.GetComponent<UIPanel>();
                }
            }
        }

        if (closestUIPanel != null)
        {
            if (closestUIPanel != currentUIPanel)
            {
                // User is now looking at a different object
                if (currentUIPanel != null)
                {
                    currentUIPanel.SetBeingViewedFalse();
                }
                currentUIPanel = closestUIPanel;
                currentUIPanel.SetBeingViewedTrue();
                Debug.Log("User is now looking at " + currentUIPanel.name);
            }
        }
        else
        {
            if (currentUIPanel != null)
            {
                // User is no longer looking at an object
                currentUIPanel.SetBeingViewedFalse();
                currentUIPanel = null;
                Debug.Log("User is no longer looking at an object");
            }
        }
    }
}















