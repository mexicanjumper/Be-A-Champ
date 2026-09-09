using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum SceneNames
    {
       IntroScene
    }

    public SceneNames SceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneName.ToString());
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
