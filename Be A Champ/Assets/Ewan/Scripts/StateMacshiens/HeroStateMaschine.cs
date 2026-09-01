using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroStateMaschine : MonoBehaviour
{
    private BattelStateMacshine BSM;
    public BaseHero hero;
    

    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD,

    }


    public TurnState currentState;

    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
    public Image ProgressBar;
    public GameObject Selector;
    //IeNumerator
    public GameObject EnemyToAttack;
    private bool actionStarted = false;
    private Vector3 startposition;
    private float animSpeed = 15f;



    void Start()
    {
        startposition = transform.position;
        cur_cooldown = Random.Range(0, 2.5f);
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattelStateMacshine>();
        currentState = TurnState.PROCESSING;
    }

   
    void Update()
    {
        //Debug.Log(currentState);
        switch (currentState)
        {
         case (TurnState.PROCESSING):
                UpgradeProgressBar();
         break; 
         case (TurnState.ADDTOLIST):
                BSM.HerosToManage.Add(this.gameObject);
                currentState = TurnState.WAITING;
         break;
         case(TurnState.WAITING): 
               //Idle 
         break; 
         
        case (TurnState.SELECTING):

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
        float calc_cooldown = cur_cooldown / max_cooldown;
        ProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0,1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;



        //animate the enemy near the hero to attack

        Vector3 enemyPosition = new Vector3(EnemyToAttack.transform.position.x+1.5f, EnemyToAttack.transform.position.y, EnemyToAttack.transform.position.z);
        while (MoveTowardsEnemy(enemyPosition))
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
        actionStarted = false;
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

    public void TakeDamage( float getDamageAmount)
    {
       hero.curHP -= getDamageAmount;
        if(hero.curHP <= 0)
        {
          currentState = TurnState.DEAD;    
        }
    }
}
