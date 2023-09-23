using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectGrabber : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;

    [SerializeField]
    private float RayDistance;

    public GameObject grabbedObj;
    public SpriteRenderer sr;
    int LayerIndex;

    PlayerScript player;

    public Camera m_camera;

    public Transform gunPivot;

    [Header("Rotation:")]
    [SerializeField] private bool rotateOverTime = true;
    [Range(0, 60)] [SerializeField] private float rotationSpeed = 4;

    private void Start()
    {
        LayerIndex = LayerMask.NameToLayer("Objects");
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();
    }

    void Update()
    {

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        RotateGun(mousePos, true);

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, RayDistance);
        if(hitInfo.collider!=null && hitInfo.collider.gameObject.layer==LayerIndex)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)&& grabbedObj==null)
            {
                grabbedObj = hitInfo.collider.gameObject;
                
                grabbedObj.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                grabbedObj.transform.position=grabPoint.position;
                grabbedObj.transform.SetParent(grabPoint);
                sr = grabbedObj.GetComponentInChildren<SpriteRenderer>();
                //grabbedObj.GetComponent<Collider2D>().enabled=false;
                //Physics2D.IgnoreLayerCollision(0, 3, true);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) )
            {
                
                grabbedObj.GetComponent<Rigidbody2D>().isKinematic = false;
                float Yvel = 0;
                if (player.rb.velocity.y > 0)
                {
                    Yvel = player.rb.velocity.y;
                }
                grabbedObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.rb.velocity.x,Yvel).normalized*30, ForceMode2D.Impulse);
                grabbedObj.transform.SetParent(null);
                grabbedObj=null;
                //Physics2D.IgnoreLayerCollision(0, 3, false);

            }

        }
        Debug.DrawRay(rayPoint.position, transform.right * RayDistance);
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }

    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - gunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotateOverTime && allowRotationOverTime)
        {
            gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        else
        {
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }



}
