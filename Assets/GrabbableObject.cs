using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private bool isBeingHeld = false;
    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component of the object
        rb = GetComponent<Rigidbody>();

        // Ensure the object has a Rigidbody
        if (rb == null)
        {
            Debug.LogError("This object is missing a Rigidbody component.");
        }
    }

    private void Update()
    {
        // Check if the object is being held
        if (isBeingHeld)
        {
            // Implement any behavior you want while the object is being held here
        }
    }

    public void GrabObject(Transform holder)
    {
        // Attach the object to the holder (usually the player's hand)
        transform.SetParent(holder);
        rb.isKinematic = true;
        isBeingHeld = true;
    }

    public void ReleaseObject()
    {
        // Detach the object from the holder and enable physics
        transform.SetParent(null);
        rb.isKinematic = false;
        isBeingHeld = false;
    }
}


