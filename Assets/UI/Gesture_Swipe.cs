using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftHandGestureDetector : MonoBehaviour
{
    public XRController leftHandController = GameObject.find("LeftHand");
    // ~ 50 cm swipe distance
    public float swipeThreshold = 0.5f;
    public GameObject uiPanel = GameObject.find("Panel");
    
    private Vector3 prevPosition;
    
    private void Start()
    {
        // if there is no object
        if (leftHandController == null)
        {
            Debug.LogError("Left hand controller not set");
            enabled = false;
        }
    }
    
    private void Update()
    {
        // vector math for the swipe
        Vector3 currentPosition = leftHandController.transform.position;
        float swipeDistance = currentPosition.x - prevPosition.x;

        // ray values for if user is looking at ui
        Ray r = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        // if user is looking at ui
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == uiPanel)
            {
                Debug.Log("User is looking at the panel");

                // check if gesture was made
                if (swipeDistance > swipeThreshold)
                {
                    uiPanel.setActive(false);
                }
            }
        }
        
        prevPosition = currentPosition;
    }
}