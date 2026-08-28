using UnityEngine;
using System.Collections;

public class EnemyScriptButton : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattelStateMacshine>();//save input enemy prefsab
    }
}
