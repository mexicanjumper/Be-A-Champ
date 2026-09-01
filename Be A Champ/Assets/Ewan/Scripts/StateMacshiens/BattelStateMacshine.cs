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
        INPUTAction1,
        INPUT2,
        INPUTAction2,
        DONE
    }

    public HeroGUI HeroInput;

    public List<GameObject> HerosToManage = new List<GameObject>();
    private HandeleTurn HeroChoise;
    public GameObject enemyButton;
    public Transform Spacer;

    public GameObject AttackPanel;
    public GameObject EnemySelectPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Players"));
        HeroInput = HeroGUI.ACTIVATE;

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);

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
                    HeroStateMaschine HSM = performer.GetComponent<HeroStateMaschine>();
                    HSM.EnemyToAttack = PerformList[0].AttackerTarget;
                    HSM.currentState = HeroStateMaschine.TurnState.ACTION;
                }
                battleStates = PerformAction.PERFORMACTION;

                break;

            case (PerformAction.PERFORMACTION):

                break;
        }

        switch (HeroInput)
        {
            case (HeroGUI.ACTIVATE):
                if (HerosToManage.Count > 0)
                {
                    HerosToManage[0].transform.Find("Selector").gameObject.SetActive(true);
                    HeroChoise = new HandeleTurn();

                    AttackPanel.SetActive(true);
                    HeroInput =HeroGUI.WAITING;
                }
                break;

            case (HeroGUI.WAITING):

                break;

            case (HeroGUI.DONE):
                heroInputDone();
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
            buttonText.text = cur_enemy.enemy.theName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent (Spacer,false);
        }
    }

    public void InputAction1()// attack button 1
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttacksGameObject = HerosToManage[0];
        HeroChoise.Type = "Players";

        AttackPanel.SetActive (false);
        EnemySelectPanel.SetActive (true);
    }

    public void InputAction2()// attack button 2
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttacksGameObject = HerosToManage[0];
        HeroChoise.Type = "Players";

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

    public void Input2(GameObject choosenEnemy)//enemy select
    {
        HeroChoise.AttackerTarget = choosenEnemy;
        HeroInput = HeroGUI.DONE;
    }

    void heroInputDone()
    {
        PerformList.Add(HeroChoise);
        EnemySelectPanel.SetActive(false);
        HerosToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        HerosToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
    }
}
