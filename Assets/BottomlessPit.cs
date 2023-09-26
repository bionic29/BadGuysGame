using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomlessPit : MonoBehaviour
{
    Scene scene;
    PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.transform.name == "Player")
        {
            //SceneManager.LoadScene(scene.buildIndex);
            player.transform.position = GameManager.LastCheckPoint;

        }
    }
}
