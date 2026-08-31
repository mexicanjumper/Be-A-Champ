using System.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateMaschine : MonoBehaviour
{
    private BattelStateMacshine BSM;
    public BaseEnemy enemy;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD,

    }


    public TurnState currentState;

    private float cur_cooldown = 0f;
    private float max_cooldown = 7f;

    private Vector3 startposition;
    public GameObject Selector;

    private bool actionStarted = false;
    public GameObject HeroToAttack;
    private float animSpeed = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = TurnState.PROCESSING;
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager"). GetComponent<BattelStateMacshine>();
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case (TurnState.PROCESSING):
                UpgradeProgressBar();
               
                break;
            case (TurnState.CHOOSEACTION):
                ChooseAction();
                currentState = TurnState.WAITING;
               
                break;
            case (TurnState.WAITING):
                //idel state
                break;
           
            case (TurnState.ACTION):
                StartCoroutine(TimeForAction());
                
                break;
            case (TurnState.DEAD):

                break;

        }
    }

    void UpgradeProgressBar()
    {
        cur_cooldown = cur_cooldown + Time.deltaTime;
        
       
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }
    }

    void ChooseAction()
    {
        HandeleTurn myAttack = new HandeleTurn();
        myAttack.Attacker = enemy.theName;
        myAttack.Type = "Enemy";
        myAttack.AttacksGameObject = this.gameObject;
        myAttack.AttackerTarget = BSM.HerosInBattle[Random.Range(0, BSM.HerosInBattle.Count)];
        BSM.CollectActions(myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;



        //animate the enemy near the hero to attack

        Vector3 heroPosition = new Vector3 (HeroToAttack.transform.position.x-1.5f, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while (MoveTowardsEnemy(heroPosition))
        {
            yield return null;
        }


        // wait abit
        yield return new WaitForSeconds(0.5f);
        //do damage

        //animate back to startposition
        Vector3 firstPosition = startposition;
        while (MoveTowardsStart(firstPosition))
        {
            yield return null;
        }


        //remove this performer from the list in BSM
            BSM.PerformList.RemoveAt(0);
        //reset BSM _> Wait
        BSM.battleStates = BattelStateMacshine.PerformAction.WAIT;
        // end coroutine
        actionStarted =false;
        //reset this enemy state
        cur_cooldown = 0f;
        currentState = TurnState.PROCESSING;
    }

    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
    private bool MoveTowardsStart(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
}
