using UnityEngine;

public class MoveAway : MonoBehaviour
{
    [SerializeField] private float distanceMultiplier = 1.3f; // Distance multiplier, set to 1.3f to move object 30% further away
    private Transform playerTransform; // The transform of the user

    public void move()
    {
        playerTransform = Camera.main.transform;
        Vector3 direction = transform.position - playerTransform.position; // Get the direction from the player to the object
        float distance = direction.magnitude; // Get the distance between the player and the object
        Vector3 targetPosition = playerTransform.position + direction.normalized * (distance * distanceMultiplier); // Calculate the target position 30% further away from the player
        transform.position = targetPosition; // Move the object to the target position
    }
}
