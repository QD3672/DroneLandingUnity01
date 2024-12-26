using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Define the bounds for movement
    public Vector2 minBounds; // Minimum X and Z
    public Vector2 maxBounds; // Maximum X and Z

    public float speed = 1f; // Speed of movement
    private Vector3 targetPosition;

    void Start()
    {
        // Set the first random target position
        SetNewTargetPosition();
    }

    void Update()
    {
        // Move the object towards the target position
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);

        // If the object reaches the target position, choose a new target
        if (Vector3.Distance(transform.localPosition, targetPosition) < 0.1f)
        {
            SetNewTargetPosition();
        }
    }

    void SetNewTargetPosition()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomZ = Random.Range(minBounds.y, maxBounds.y);
        targetPosition = new Vector3(randomX, transform.localPosition.y, randomZ);
    }
}
