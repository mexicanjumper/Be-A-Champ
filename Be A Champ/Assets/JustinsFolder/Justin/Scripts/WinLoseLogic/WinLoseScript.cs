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
    [SerializeField] private string sceneName;

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

    public void RestartBattle()
    {
        //reload the scene, can add scene name as a string, but I've made a string variable to edit in editor
        SceneManager.LoadScene(sceneName); 
    }

    public void NextScene()
    {
        //this will allow you to load the next scene on the winning condition
        SceneManager.LoadScene(sceneName);
    }
}
