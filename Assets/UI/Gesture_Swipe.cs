using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class Gesture_Swipe : MonoBehaviour
{
    public XRController leftHand;
    public XRController rightHand;
    // ~ 50 cm swipe distance
    public float swipeThreshold = 0.5f;
    public GameObject uiPanel;
    public Material table;
    
    private Vector3 prevPosition;

    public float rayLength = 10f;
    public LayerMask layerMask;
    
    private void Start()
    {

    }
    
    private void Update()
    {
        // vector math for the swipe
        //Vector3 currentPosition = leftHand.transform.position;
        //float swipeDistance = currentPosition.x - prevPosition.x;

        // Cast a ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        // Draw a line in the scene view to visualize the ray
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, Color.green);
        // Check if the ray hits any objects on the specified layer mask
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength, layerMask))
        {
            // Change the material of the hit object
            hitInfo.transform.GetComponent<Renderer>().material.color = Color.red;
        }

        /*
        // ray values for if user is looking at ui
        RaycastHit hit;
        
        // if user is looking at ui
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log(hit);

            if (hit.collider.gameObject == uiPanel)
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = table;
                }

                Debug.Log("User is looking at the panel");

                // check if gesture was made
                if (swipeDistance > swipeThreshold)
                {
                    uiPanel.SetActive(false);
                }
            }
        }
        
        prevPosition = currentPosition;
        */
    }
}