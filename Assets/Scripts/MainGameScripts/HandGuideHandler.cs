using UnityEngine;

public class HandGuideHandler : MonoBehaviour
{
    public float followSpeed = 10f; // Speed of the hand movement
    private Vector3 targetPosition;

    void Update()
    {
        // Convert mouse position to world position
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        // Move the hand smoothly towards the target
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
