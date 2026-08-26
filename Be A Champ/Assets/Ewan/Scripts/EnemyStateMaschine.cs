using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateMaschine : MonoBehaviour
{
    public BaseEnemy enemy;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = TurnState.PROCESSING;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case (TurnState.PROCESSING):
                UpgradeProgressBar();
                break;
            case (TurnState.ADDTOLIST):

                break;
            case (TurnState.WAITING):

                break;
            case (TurnState.SELECTING):

                break;
            case (TurnState.ACTION):

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
            currentState = TurnState.ADDTOLIST;
        }
    }
}
