using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{ // You must set the cursor in the inspector.
  // public Texture2D[] crosshair;
    int cursorNo;
    Vector2 cursorOffset, touchPosition;
    SpriteRenderer sr;
    public Sprite[] sprites;
    Transform target;

    void Start()
    {
        cursorNo = 0;
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.transform.position = transform.position;

        //set the cursor origin to its centre. (default is upper left corner)
        //cursorOffset = new Vector2(crosshair[cursorNo].width / 2, crosshair[cursorNo].height / 2);
        //Sets the cursor to the Crosshair sprite with given offset 
        //and automatic switching to hardware default if necessary
        //Cursor.SetCursor(crosshair[cursorNo], cursorOffset, CursorMode.Auto);
    }


    void UpdateTarget()
    {
        if (this.gameObject.activeInHierarchy)
        {

            GameObject[] chicks = GameObject.FindGameObjectsWithTag("BloodStains");
            //GameObject[] chicks = GameObject.FindGameObjectsWithTag("Movables");

            float shortestDistance = Mathf.Infinity;
            GameObject nearestChick = null;
            foreach (GameObject chicken in chicks)
            {
                if (chicken != null)
                {
                    float distancetoObj = Vector3.Distance(touchPosition, chicken.transform.position);
                    if (distancetoObj <= shortestDistance)
                    {
                        shortestDistance = distancetoObj;
                        nearestChick = chicken;
                    }
                }
            }
            if (nearestChick != null && shortestDistance <= 4)
            {
                target = nearestChick.transform;
            }
            else
            {
                target = null;
            }
        }
    }



    private void Update()
    {
        UpdateTarget();

        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        sr.sprite = sprites[cursorNo];
        if (target == null)
        {
            //touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorNo = 0;
            transform.position = touchPosition;
            sr.transform.position = transform.position;
        }
        else if (target != null)
        {
            cursorNo = 1;
            sr.transform.position = target.position;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodStains"))
        {
            cursorNo = 1;
            sr.transform.position = collision.transform.position;
            //Cursor.SetCursor(crosshair[cursorNo], cursorOffset, CursorMode.Auto);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodStains"))
        {
            cursorNo = 1;
            sr.transform.position = collision.transform.position;
            //Cursor.SetCursor(crosshair[cursorNo], cursorOffset, CursorMode.Auto);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BloodStains"))
        {
            cursorNo = 0;
            sr.transform.position = transform.position;
            //Cursor.SetCursor(crosshair[cursorNo], cursorOffset, CursorMode.Auto);
        }
    }
}
