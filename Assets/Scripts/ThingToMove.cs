using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThingToMove : MonoBehaviour
{

    PlayerScript player;
    bool Movable;

    // Start is called before the first frame update
    void Start()
    {
        Movable = false;
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Movable)
        {
            transform.position = player.transform.position+new Vector3(0,1,0);
        }
    }

    public void MoveObject()
    {
        Movable = true;
    }
    public void DropObject()
    {
        Movable = false;
    }
}
