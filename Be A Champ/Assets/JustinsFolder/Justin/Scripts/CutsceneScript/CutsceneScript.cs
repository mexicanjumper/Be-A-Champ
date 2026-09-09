using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    public enum NextSceneName
    {
        JustinsScene,
        IntroScene
    }

    [SerializeField] private NextSceneName nextScene;

    public void StartNextScene()
    {
        SceneManager.LoadScene(nextScene.ToString());
    }
}
