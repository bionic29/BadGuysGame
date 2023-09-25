using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGrapple : MonoBehaviour
{
    public static bool GrappleEnabled;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GrappleEnabled = true;
    }
}
