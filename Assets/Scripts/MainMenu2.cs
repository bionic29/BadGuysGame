using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartCutscene()
    {
        SceneManager.LoadScene("Cutscene");
    }
}

