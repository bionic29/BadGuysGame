using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToActivate : MonoBehaviour
{

    public GameObject ThingToActive;
    Animator anim;
    int ObjectsOn;

    //public BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        ThingToActive.SetActive(false);

        anim = GetComponent<Animator>();
        anim.SetBool("Open", false);
    }

    private void Update()
    {
        if(ObjectsOn > 0)
        {
            anim.SetBool("Open", true);
            ThingToActive.SetActive(true);
        }
        else
        {
            anim.SetBool("Open", false); 
            ThingToActive.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag=="Player" || collision.transform.tag == "Movables") 
        {
            ObjectsOn++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Movables")
        {
            ObjectsOn--;
        }
    }
}
