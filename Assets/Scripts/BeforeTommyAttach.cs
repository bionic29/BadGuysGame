using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeTommyAttach : MonoBehaviour
{
    bool TouchedPlayer;
    public Dialogue DialogueOBJ;
    private void Update()
    {
        if (TouchedPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerScript.TommyEquipped = true;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!DialogueOBJ.dialogueDone)
            DialogueOBJ.gameObject.SetActive(true);

            TouchedPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TouchedPlayer = false;
        }
    }


    /*
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
    */

}
