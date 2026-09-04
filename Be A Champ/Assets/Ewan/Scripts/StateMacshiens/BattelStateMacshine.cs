using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class BattelStateMacshine : MonoBehaviour
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
        CHEACKALIVE,
        WIN,
        LOSE,
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
        Input3,
        DONE
    }

    public HeroGUI HeroInput;

    public List<GameObject> HerosToManage = new List<GameObject>();
    private HandeleTurn HeroChoise;
    public GameObject enemyButton;
    public Transform Spacer;

    public GameObject AttackPanel;
    public GameObject EnemySelectPanel;
    public GameObject MagicPanal;

    public Transform actionSpacer;
    public Transform magicSpacer;
    public GameObject actionButton;
    public GameObject magicButton;
    private List<GameObject> atkBtns = new List<GameObject>();

    //enemy buttons
    private List<GameObject> enemyBtns = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Players"));
        HeroInput = HeroGUI.ACTIVATE;

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);
        MagicPanal.SetActive(false);

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
                    for (int i = 0; i < HerosInBattle.Count; i++)
                    {
                        if (PerformList[0].AttackerTarget == HerosInBattle[i])
                        {
                            ESM.HeroToAttack = PerformList[0].AttackerTarget;
                            ESM.currentState = EnemyStateMaschine.TurnState.ACTION;
                            break;
                        }
                        else
                        {
                            PerformList[0].AttackerTarget = HerosInBattle[Random.Range(0, HerosInBattle.Count)];
                            ESM.HeroToAttack = PerformList[0].AttackerTarget;
                            ESM.currentState = EnemyStateMaschine.TurnState.ACTION;
                        }
                    }


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

            case (PerformAction.CHEACKALIVE):
                if(HerosInBattle.Count < 1)
                {
                    battleStates = PerformAction.LOSE;
                }
                else if(EnemysInBattle.Count < 1)
                {
                    battleStates = PerformAction.WIN;
                }
                else
                {
                    ClearAttackPanel();
                    HeroInput = HeroGUI.ACTIVATE;
                }
                break;

            case (PerformAction.LOSE):
                {

                }
                break;

            case (PerformAction.WIN):
                {

                }
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

                    CreateAttackButtons();

                    HeroInput = HeroGUI.WAITING;
                }
                break;

            case (HeroGUI.WAITING):

                break;

            case (HeroGUI.DONE):
                heroInputDone();
                break;
        }
    }

    public void CollectActions(HandeleTurn input)
    {
        PerformList.Add(input);
    }

    public void EnemyButtons()
    {
        //cleanup
        foreach(GameObject enemyBtn in enemyBtns)
        {
            Destroy(enemyBtn);
        }

        enemyBtns.Clear();
        //create buttons

        foreach (GameObject enemy in EnemysInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemyScriptButton button = newButton.GetComponent<EnemyScriptButton>();

            EnemyStateMaschine cur_enemy = enemy.GetComponent<EnemyStateMaschine>();


            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = cur_enemy.enemy.theName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent(Spacer, false);
            enemyBtns.Add(newButton);
        }
    }

    public void InputAction1()// attack button 1
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttacksGameObject = HerosToManage[0];
        HeroChoise.Type = "Players";
        HeroChoise.choosenAttack = HerosToManage[0].GetComponent<HeroStateMaschine>().hero.attacks[0];
        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

   /* public void InputAction2()// attack button 2
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttacksGameObject = HerosToManage[0];
        HeroChoise.Type = "Players";

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }*/

    public void Input2(GameObject choosenEnemy)//enemy select
    {
        HeroChoise.AttackerTarget = choosenEnemy;
        HeroInput = HeroGUI.DONE;
    }

    void heroInputDone()
    {
        PerformList.Add(HeroChoise);
        ClearAttackPanel();
        


        HerosToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        HerosToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
    }

    void ClearAttackPanel()
    {
        EnemySelectPanel.SetActive(false);
        AttackPanel.SetActive(false);
        MagicPanal.SetActive(false);

        foreach (GameObject atkBtn in atkBtns)
        {
            Destroy(atkBtn);
        }
        atkBtns.Clear();
    }

    void CreateAttackButtons()
    {
        GameObject AttackButton = Instantiate(actionButton) as GameObject;
        TextMeshProUGUI AttackButtonText = AttackButton.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        AttackButtonText.text = "Attack";
        AttackButton.GetComponent<Button>().onClick.AddListener(() => InputAction1());
        AttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(AttackButton);
        //Magic Attack Button
        GameObject MagicAttackButton = Instantiate(actionButton) as GameObject;
        TextMeshProUGUI MagicAttackButtonText = MagicAttackButton.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        MagicAttackButtonText.text = "Magic";

        MagicAttackButton.GetComponent<Button>().onClick.AddListener(() => Input3());
        MagicAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(MagicAttackButton);

        if (HerosToManage[0].GetComponent<HeroStateMaschine>().hero.MagicAttack.Count > 0)
        {
            foreach (BaseAttacks magicATK in HerosToManage[0].GetComponent<HeroStateMaschine>().hero.MagicAttack)
            {
                GameObject MagicButton = Instantiate(magicButton) as GameObject;
                TextMeshProUGUI MagicButtonText = MagicButton.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
                MagicButtonText.text = magicATK.attackName;
                AttackButton ATB = MagicButton.GetComponent<AttackButton>();
                ATB.magicAttackToPerform = magicATK;
                MagicButton.transform.SetParent(magicSpacer, false);
                atkBtns.Add(MagicButton);

            }

        }

        else
        {

            MagicAttackButton.GetComponent<Button>().interactable = false;

        }
    }

    public void Input4 (BaseAttacks choosenMagic)//magic select
    {
        HeroChoise.Attacker = HerosToManage[0].name;
        HeroChoise.AttacksGameObject = HerosToManage[0];
        HeroChoise.Type = "Players";

        HeroChoise.choosenAttack = choosenMagic;
        MagicPanal.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

    public void Input3()
    {
        AttackPanel.SetActive(false);
        MagicPanal.SetActive(true);
    }
}
