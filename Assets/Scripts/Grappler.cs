using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{

    public Camera mainCam;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;

    PlayerScript player;
    public static bool isGrappling = false;

    Transform target;
    public LayerMask grappleMask;
    // Start is called before the first frame update
    void Start()
    {
        distanceJoint.enabled=false;
        player=GetComponentInParent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.J) && target!=null)
        {
            
                //Vector2 mousepos = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosw x ition);
                lineRenderer.SetPosition(0, target.position);
                lineRenderer.SetPosition(1, player.transform.position);
                distanceJoint.connectedAnchor = target.position;
                distanceJoint.enabled = true;
                lineRenderer.enabled = true;
            isGrappling=true;

            //StartGrapple();
        }
        else if(Input.GetKeyUp(KeyCode.J))
        {
            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
            Invoke(nameof(LetGo),1f);
            player.GetComponent<Rigidbody2D>().AddForce(player.rb.velocity, ForceMode2D.Impulse);

        }
        if (distanceJoint.enabled)
            {
                lineRenderer.SetPosition(1, player.transform.position);
            }
        


            /*
            else if(Input.GetKeyUp(KeyCode.X))
            {
                distanceJoint.enabled = false;
                lineRenderer.enabled = false;
            }

        */
    }

    void LetGo()
    {
        isGrappling = false;
    }
    /*
    void StartGrapple()
    {
        Vector2 direction = target.position - player.transform.position;

        RaycastHit2D Hit=Physics2D.Raycast(player.transform.position, direction,10,grappleMask);
        if(Hit.collider != null)
        {
            isGrappling=true;
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;

            StartCoroutine(Grapple());
            

        }

    }


    IEnumerator Grapple()
    {
        float t = 0;
        float time = 2;

        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, player.transform.position);
        
        Vector2 newPos;
        for (; t < time; t += 100 * Time.deltaTime)
        {
            newPos = Vector2.Lerp(player.transform.position, target.position, t / time);
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, newPos);
        distanceJoint.connectedAnchor = target.position;
        lineRenderer.SetPosition(1, target.position);
                yield return null;
        }
        


    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodStains"))
        {
            target=collision.transform;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodStains"))
        {
            target = collision.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodStains"))
        {
            target = null;
        }

    }
    

}
