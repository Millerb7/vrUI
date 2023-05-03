using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class Gesture_Swipe : MonoBehaviour
{
    public float maxDistance = 10f;
    public string targetTag = "UIPanel";
    //public HandPoseId poseId = HandPoseId.ThumbsUp;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                OVRHand hand = GetComponent<OVRHand>();
                // if (hand.IsPoseValid(poseId))
                // {
                //     Debug.Log("Thumbs up detected!");
                // }
            }
        }
    }
}