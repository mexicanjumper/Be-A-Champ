using UnityEngine;
using System.Collections;

public class EnemyScriptButton : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattelStateMacshine>().Input2(EnemyPrefab);//save input enemy prefsab
    }
}
