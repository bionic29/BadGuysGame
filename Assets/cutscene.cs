using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndCutscene;
    }

    private void EndCutscene(VideoPlayer vp)
    {
        // When the cutscene ends, transition to the Level 1 scene.
        SceneManager.LoadScene(2);
    }
}
