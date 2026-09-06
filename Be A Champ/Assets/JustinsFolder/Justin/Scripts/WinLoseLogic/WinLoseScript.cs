using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{
    //variables
    [Header("UI")]
    //[SerializeField] private GameObject winLoseUI;
    [SerializeField] private GameObject winBattleText;
    [SerializeField] private GameObject loseBattleText;

    [Header("Scene Name")]
    //first level getting introduced to world
    [SerializeField] private string sceneZero;
    //second level, first battle
    [SerializeField] private string sceneOne;
    //third level, onto next battle
    [SerializeField] private string sceneTwo;
    //fourth level, second and final battle
    [SerializeField] private string sceneThree;
    //fifth level, final scene with ending cutscene
    [SerializeField] private string sceneFour;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winBattleText.SetActive(false);
        loseBattleText.SetActive(false);
        //winLoseUI.SetActive(false);
    }

    public void WinBattle()
    {
        //if all enemies health equals 0, add logic below

        //the below logic is the UI to be displayed when enemies are dead
        //winLoseUI.SetActive(true);
        winBattleText.SetActive(true);
    }

    public void LoseBattle()
    {
        //if all heroes health equals 0, add logic below

        //the below logic is the UI to be displayed when heroes are dead
        //winLoseUI.SetActive(true);
        loseBattleText.SetActive(true);
    }

    //these are to be put on main menu play button
    public void NextSceneZero()
    {
        //this will allow you to load the next scene on the winning condition
        SceneManager.LoadScene(sceneZero);
    }

    //these are to be put on buttons
    public void RestartBattleOne()
    {
        //reload the scene, can add scene name as a string, but I've made a string variable to edit in editor
        SceneManager.LoadScene(sceneOne); 
    }

    //these are to be put on buttons
    public void NextSceneTwo()
    {
        //this will allow you to load the next scene on the winning condition
        SceneManager.LoadScene(sceneTwo);
    }

    //these are to be put on buttons
    public void NextSceneThree()
    {
        //this will allow you to load the next scene on the winning condition
        SceneManager.LoadScene(sceneThree);
    }

    //these are to be put on buttons
    public void RestartBattleTwo()
    {
        //reload the scene, can add scene name as a string, but I've made a string variable to edit in editor
        SceneManager.LoadScene(sceneThree);
    }

    //these are to be put on buttons
    public void NextSceneFour()
    {
        //this will allow you to load the next scene on the winning condition
        SceneManager.LoadScene(sceneFour);
    }
}
