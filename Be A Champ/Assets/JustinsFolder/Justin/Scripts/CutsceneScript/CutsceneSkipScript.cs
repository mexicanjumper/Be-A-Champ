using UnityEngine;
using UnityEngine.SceneManagement;  

public class CutsceneSkipScript : MonoBehaviour
{
    [SerializeField] private CutsceneScript cutsceneScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            cutsceneScript.StartNextScene();    
        }    
    }
}
