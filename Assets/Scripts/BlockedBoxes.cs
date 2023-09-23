using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedBoxes : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Movables"&&PlayerScript.TommyEquipped)
        {
            Rigidbody2D Collisionrb = collision.transform.GetComponent<Rigidbody2D>();
            if (Collisionrb.velocity.magnitude > 15)
            {
                Debug.Log(Collisionrb.velocity.magnitude);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log(Collisionrb.velocity.magnitude);
            }
        }
    }
}
