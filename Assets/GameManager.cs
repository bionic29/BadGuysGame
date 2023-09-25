using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {

        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex > 0)
        {
            PlayerScript.TommyEquipped = true;
        }
        else
        {
            PlayerScript.TommyEquipped = false;
        }
    }
    
}
