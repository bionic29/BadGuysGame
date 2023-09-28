using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGunType : MonoBehaviour
{
    public GameObject Grab, Grapple;
    Transform pivotPoint;
    PlayerScript player;
    int WeaponType;
    // Start is called before the first frame update
    private void Start()
    {
        WeaponType = 1;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponType = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&& EnableGrapple.GrappleEnabled)
        {
            WeaponType = 2;
        }

        if (WeaponType == 1)
        {
            Grab.SetActive(true);
            Grapple.SetActive(false);
        }
        else if (WeaponType == 2)
        {
            Grab.SetActive(false);
            Grapple.SetActive(true);
        }


    }
}
