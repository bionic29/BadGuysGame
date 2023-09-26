using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static bool Checked;
    PlayerScript player;
    //GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        //GM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();
        if (Checked)
        {
            player.transform.position = transform.position;
        }    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("CheckPoint!");
            GameManager.LastCheckPoint = transform.position;
        }
    }
}
