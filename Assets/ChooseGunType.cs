using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGunType : MonoBehaviour
{
    public GameObject Grab, Grapple;
    PlayerScript player;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Grab.SetActive(true);
            Grapple.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Grab.SetActive(false);
            Grapple.SetActive(true);
        }
    }
}
