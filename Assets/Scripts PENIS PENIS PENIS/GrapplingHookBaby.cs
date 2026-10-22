using UnityEngine;

public class GrapplingHookBaby : MonoBehaviour
{
    public KeyCode swingKey = KeyCode.Mouse0;

    public LineRenderer lr;
    public Transform gunTip, cam, player;
    public LayerMask whatIsGrappleable;

    public float maxSwingDistance = 10000f;

    public float pullForce = 3000;            // Uses ForceMode.Force (respects mass)
    public float ropeRestitutionForce = 4500f; // Uses ForceMode.Force (respects mass)

    private Vector3 swingPoint;
    private float targetRopeLength;
    public bool isSwinging = false;

    private Rigidbody playerRb;
    private Rigidbody hitObjectRb;
    private Vector3 hitLocalOffset;
    private Vector3 currentGrapplePosition;

    void Start()
    {
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        Vector2 scrollDelta = Input.mouseScrollDelta;

        if (Input.GetKeyDown(swingKey)) StartSwing();
        if (Input.GetKeyUp(swingKey)) StopSwing();

        if (isSwinging)
        {
            if (hitObjectRb != null)
            {
                swingPoint = hitObjectRb.transform.TransformPoint(hitLocalOffset);
            }

            // Smoothly shorten/lengthen rope via scroll wheel
            if (scrollDelta.y > 0f)
            {
                targetRopeLength *= 1.1f;
            }
            else if (scrollDelta.y < 0f)
            {
                targetRopeLength *= 0.9f;
            }
        }
    }

    void FixedUpdate()
    {
        if (isSwinging)
        {
            if (hitObjectRb != null)
            {
                swingPoint = hitObjectRb.transform.TransformPoint(hitLocalOffset);
            }

            ApplyForcePhysics();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void StartSwing()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxSwingDistance, whatIsGrappleable))
        {
            swingPoint = hit.point;
            isSwinging = true;

            if (hit.collider.attachedRigidbody != null)
            {
                hitObjectRb = hit.collider.attachedRigidbody;
                hitLocalOffset = hit.transform.InverseTransformPoint(hit.point);
            }
            else
            {
                hitObjectRb = null;
            }

            targetRopeLength = Vector3.Distance(player.position, swingPoint);
            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    private void StopSwing()
    {
        isSwinging = false;
        hitObjectRb = null;
        lr.positionCount = 0;
    }

    private void ApplyForcePhysics()
    {
        if (playerRb == null) return;

        Vector3 directionToHook = (swingPoint - player.position).normalized;
        float currentDistance = Vector3.Distance(player.position, swingPoint);

        // 1. Continuous baseline pull force on player (Mass Respected)
        playerRb.AddForce(directionToHook * pullForce, ForceMode.Force);

        // 2. Continuous baseline pull force on hit object (Mass Respected)
        if (hitObjectRb != null)
        {
            hitObjectRb.AddForce(-directionToHook * pullForce, ForceMode.Force);
        }

        // 3. Dynamic Constraint Force (Triggers when shortening or stretching the rope)
        if (currentDistance > targetRopeLength)
        {
            // Dampen relative outward velocity so they don't bounce forever
            float outwardSpeed = Vector3.Dot(playerRb.linearVelocity, -directionToHook);
            if (outwardSpeed > 0)
            {
                playerRb.linearVelocity += directionToHook * outwardSpeed;
            }

            // Also dampen the hit object's velocity relative to the rope axis
            if (hitObjectRb != null)
            {
                float objectOutwardSpeed = Vector3.Dot(hitObjectRb.linearVelocity, directionToHook);
                if (objectOutwardSpeed > 0)
                {
                    hitObjectRb.linearVelocity -= directionToHook * objectOutwardSpeed;
                }
            }

            // Calculate how far past the target constraint length the rope is stretched
            float overshoot = currentDistance - targetRopeLength;
            Vector3 tensionForceVector = directionToHook * overshoot * ropeRestitutionForce;

            // Switched to ForceMode.Force so Unity naturally divides the force by each object's mass
            playerRb.AddForce(tensionForceVector, ForceMode.Force);

            if (hitObjectRb != null)
            {
                hitObjectRb.AddForce(-tensionForceVector, ForceMode.Force);
            }
        }
    }

    void DrawRope()
    {
        if (!isSwinging) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, swingPoint, Time.deltaTime * 12f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }
}
