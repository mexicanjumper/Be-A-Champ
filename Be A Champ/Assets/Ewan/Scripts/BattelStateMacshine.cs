using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemysInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Players"));


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
}
