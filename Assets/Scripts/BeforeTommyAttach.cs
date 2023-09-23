using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeTommyAttach : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerScript.TommyEquipped = true;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerScript.TommyEquipped = true;
                gameObject.SetActive(false);
            }
        }
    }
}
