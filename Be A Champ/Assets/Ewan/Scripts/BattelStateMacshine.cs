using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BattelStateMacshine : MonoBehaviour
{   
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
    }


    public PerformAction battleStates;

    public List<HandeleTurn> PerformList = new List<HandeleTurn>();
   
    public List<GameObject> HerosInBattle = new List<GameObject>();
    public List<GameObject> EnemysInBattle = new List<GameObject>();

    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }

    public HeroGUI HeroInput;

    public List<GameObject> HerosToManage = new List<GameObject>();
    private HandeleTurn HeroChoise;
    public GameObject enemyButton;
    public Transform Spacer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Players"));

        EnemyButtons();


    }

    // Update is called once per frame
    void Update()
    {
        switch (battleStates)
        {
            case (PerformAction.WAIT):
                if (PerformList.Count > 0)
                {
                    battleStates = PerformAction.TAKEACTION;
                }
                break;

            case (PerformAction.TAKEACTION):
                GameObject performer = PerformList[0].AttacksGameObject;
                if (PerformList[0].Type == "Enemy")
                {
                    EnemyStateMaschine ESM = performer.GetComponent<EnemyStateMaschine>();
                    ESM.HeroToAttack = PerformList[0].AttackerTarget;
                    ESM.currentState =EnemyStateMaschine.TurnState.ACTION;
                }
                if (PerformList[0].Type == "Players")
                {

                }
                battleStates = PerformAction.PERFORMACTION;

                break;

            case (PerformAction.PERFORMACTION):
                break;
        }
    }

    public void CollectActions( HandeleTurn input)
    {
        PerformList.Add(input);
    }

    void EnemyButtons()
    {
        foreach(GameObject enemy in EnemysInBattle)
        {
            GameObject newButton = Instantiate (enemyButton) as GameObject;
            EnemyScriptButton button = newButton.GetComponent<EnemyScriptButton>();

            EnemyStateMaschine cur_enemy = enemy.GetComponent<EnemyStateMaschine>();

            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = cur_enemy.enemy.name;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent (Spacer,false);
        }
    }
}
