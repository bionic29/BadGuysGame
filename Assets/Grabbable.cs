using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    Rigidbody2D rb;
    TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 15)
        {
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
    }
}
