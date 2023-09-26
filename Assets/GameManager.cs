using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Scene scene;
    public static Vector2 LastCheckPoint = new Vector2(-5,-2.5f);
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
