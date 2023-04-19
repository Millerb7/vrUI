using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastRay : MonoBehaviour
{
    public float raycastDistance = 10f;
    public Material mat;
    private Material orig;
    Renderer panelRenderer;
    private bool lookin = false;

    private void start() {
        mat = Resources.Load<Material>("Selected_UI");
        orig = Resources.Load<Material>("Glass");
        panelRenderer.material = orig;
    }

    private void Update()
    {
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 headDirection = Camera.main.transform.forward;

        Vector3 rayEndPosition = headPosition + (headDirection * 10f);

        Debug.DrawLine(headPosition, rayEndPosition, Color.green);

        // Create a ray that projects forward from the player's head
        Ray ray = new Ray(transform.position, transform.forward);

        // Create a variable to store information about the object hit by the ray
        RaycastHit hit;

        // Cast the ray and check if it hits an object within a certain distance
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Log the name of the object hit by the ray
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("UIPanel"))
            {
                panelRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                lookin = true;
                if (panelRenderer != mat)
                {
                    panelRenderer.material = mat;
                    Debug.Log("User is looking at the panel");
                }
            } else {
                lookin = false;
            }
        } else {
            lookin = false;
        }

        if (!lookin && panelRenderer.material != orig)
        {
            panelRenderer.material = orig;
        }
    }
}
