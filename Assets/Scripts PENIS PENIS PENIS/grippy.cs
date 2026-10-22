using UnityEngine;

public class FirstPersonGeckoAnchor : MonoBehaviour
{
    [Header("Setup")]
    public Transform playerCamera;       // Assign your Main Camera
    public LayerMask climbableLayer;     // Set to your "Climbable" layer

    [Header("Settings")]
    public float gripReachDistance = 2.5f; // How far away a wall can be to grab it
    public float maxLeashDistance = 1.0f;  // Maximum distance allowed from the grip point
    public KeyCode leftHandGripKey = KeyCode.Mouse3; // Left-click to grip

    private bool isGripping = false;
    private Vector3 gripWorldPoint;      // The exact point on the wall the hand grabbed

    void Update()
    {
        HandleGripInput();
    }

    void LateUpdate()
    {
        // Enforce the tether constraint in LateUpdate so it overrides 
        // any movement applied by walking scripts or physics this frame
        if (isGripping)
        {
            EnforceLeashConstraint();
        }
    }

    void HandleGripInput()
    {
        if (Input.GetKeyDown(leftHandGripKey))
        {
            TryGrip();
        }

        if (Input.GetKeyUp(leftHandGripKey) && isGripping)
        {
            isGripping = false;
        }
    }

    void TryGrip()
    {
        RaycastHit hit;
        // Raycast straight from the center of the screen
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, gripReachDistance, climbableLayer))
        {
            isGripping = true;
            gripWorldPoint = hit.point; // Lock down the anchor position
        }
    }

    void EnforceLeashConstraint()
    {
        // Calculate the vector from the anchor point to the player's current position
        Vector3 fromGripToPlayer = transform.position - gripWorldPoint;
        float currentDistance = fromGripToPlayer.magnitude;

        // If the player tries to move past the allowed leash distance
        if (currentDistance > maxLeashDistance)
        {
            // Clamp their position strictly to the max radius boundary
            Vector3 clampedOffset = fromGripToPlayer.normalized * maxLeashDistance;
            transform.position = gripWorldPoint + clampedOffset;

            // Optional: If using a Rigidbody, kill outward velocity so they don't jitter
            if (TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                // Stop momentum moving AWAY from the grip point
                float outwardVelocity = Vector3.Dot(rb.linearVelocity, fromGripToPlayer.normalized);
                if (outwardVelocity > 0)
                {
                    rb.linearVelocity -= fromGripToPlayer.normalized * outwardVelocity;
                }
            }
        }
    }

    // Optional: Draw the leash boundary in the editor scene view for easy debugging
    private void OnDrawGizmos()
    {
        if (isGripping)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(gripWorldPoint, maxLeashDistance);
            Gizmos.DrawLine(gripWorldPoint, transform.position);
        }
    }
}
