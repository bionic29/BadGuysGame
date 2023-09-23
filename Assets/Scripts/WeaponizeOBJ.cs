using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponizeOBJ : MonoBehaviour
{
    ObjectGrabber objectGrabber;
    public GameObject weapon;
    public SpriteRenderer sr;
    bool equipped;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        objectGrabber=FindObjectOfType<ObjectGrabber>().GetComponent<ObjectGrabber>();
        //sr.GetComponent<SpriteRenderer>();
        equipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && objectGrabber.grabbedObj != null && !equipped)
        {
            sr.sprite = objectGrabber.sr.sprite;
            objectGrabber.grabbedObj.SetActive(false);
            equipped = true;
            anim.SetBool("Equipped", true);
        }   
        else if(Input.GetKeyDown(KeyCode.F) && equipped)
        {
            objectGrabber.grabbedObj.SetActive(true);
            anim.SetBool("Equipped", false);
            sr.sprite = null;
            equipped = false;
        }
    }
}
