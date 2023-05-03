using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastRay : MonoBehaviour
{
    public string targetTag = "UIPanel";
    public float threshold = 0.5f;

    private void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject target in targets)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            if (angle < threshold)
            {
                Debug.Log("Looking at panel " + target.name);
            }
        }
    }
}


