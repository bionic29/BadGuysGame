using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToActivate : MonoBehaviour
{

    public GameObject ThingToActive;
    // Start is called before the first frame update
    void Start()
    {
        ThingToActive.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Movables")) 
        {
            ThingToActive.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Movables"))
        {
            ThingToActive.SetActive(false);
        }
    }
}
