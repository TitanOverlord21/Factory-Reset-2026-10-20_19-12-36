using UnityEngine;

public class RigidbodyMassModifier : MonoBehaviour
{
    public float mass = 1.0f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = mass;
        }
    }

    //void Update()
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        rb.mass = mass;
    //    }
    //}
}