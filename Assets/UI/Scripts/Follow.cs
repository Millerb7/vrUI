using UnityEngine;
using Oculus.Interaction;

public class Follow : MonoBehaviour, IActiveState
{
    public bool isActive = false;
    public float distance = .75f;
    public float height = .2f;

    private Transform cameraTransform;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if (isActive)
        {
            transform.position = cameraTransform.position + cameraTransform.forward * distance + Vector3.up * height;
            transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
            transform.rotation *= Quaternion.Euler(0, 90, 0);
        }
    }

    public void Reset()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    public bool Active
    {
        get { return isActive; }
        set { isActive = value; }
    }
}




