using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    public enum NextSceneName
    {
      Level1,
      Level2,
        FirstBattle,
      FinalBattle,
    }

    [SerializeField] private NextSceneName nextScene;


    [SerializeField] private string endCreditsSceneName;

    public void StartNextScene()
    {
        SceneManager.LoadScene(nextScene.ToString());
    }

    public void StartEndCredits()
    {
        SceneManager.LoadScene(endCreditsSceneName);   
    }
}
