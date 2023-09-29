using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Vector3 movement;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public bool JumpAble, isGrappling, GrappleActive;
    //ThingToMove thingToMove;

    private bool isGrabbing = false;
    private Transform grabbedObject;
    private Vector3 objectOffset;

    public GrapplingRope Rope;

    public int jumpHeight;

    public static bool TommyEquipped;
    public GameObject Tommy;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrappling = false;
        
        transform.position = GameManager.LastCheckPoint;


    }

    // Update is called once per frame
    void Update()
    {
            float x = Input.GetAxis("Horizontal");
        if (!isGrappling && !GrappleActive) 
        {
            rb.velocity = new Vector2(x * 7, rb.velocity.y);
        }
        else
        {
            rb.velocity += new Vector2(x/50 , 0);
        }

        if (rb.velocity.magnitude < 0.2f)
        {
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Run", true);
        }

        if (x > 0)
        {
            sr.flipX = false;
            //transform.localScale=new Vector3(1,1,1);
        }
        else if (x < 0)
        {
            sr.flipX = true;
            //transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& JumpAble)
        {
            rb.velocity = new Vector3(movement.x, jumpHeight);
            
        }

        if (TommyEquipped)
        {
            Tommy.SetActive(true);
        }
        else
        {
            Tommy.SetActive(false);
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GrappleActive)
        {
            if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Movables")
        {
                isGrappling = false;
                JumpAble = true;
                anim.SetBool("Jump", false);
            }
    }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GrappleActive)
        {
            if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Movables")
            {
                isGrappling = false;
                JumpAble = true;
                anim.SetBool("Jump", false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Movables")
        {
            anim.SetBool("Jump", true);
            JumpAble = false;
        }

    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GrappleActive)
        {
            if (collision.gameObject.tag == "Floor" )
            {
                isGrappling = false;
                JumpAble = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            JumpAble = false;
        }

    }
    */

    public void SetGrapple() 
    {
        isGrappling = true;
    }

}
