using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageDoor : MonoBehaviour
{
    Animator anim;
    bool TouchedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", false);
    }

    private void Update()
    {
        if (TouchedPlayer)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SceneManager.LoadScene("Stage 2");

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TouchedPlayer = true;
            anim.SetBool("Open", true);
        }
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("Stage 2");
        }
    }
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TouchedPlayer = false;
            anim.SetBool("Open", false);
        }
    }
}
