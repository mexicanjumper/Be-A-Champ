using UnityEngine;
using System.Collections;

public class EnemyScriptButton : MonoBehaviour
{
    public GameObject EnemyPrefab;
    

    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattelStateMacshine>().Input2(EnemyPrefab);//save input enemy prefsab
    }

    public void HideSelector()
    {
        
      
            EnemyPrefab.transform.Find("Selector").gameObject.SetActive(false);
            
        
         
    }

    public void ShowSelector()
    {
        EnemyPrefab.transform.Find("Selector").gameObject.SetActive(true);

    }






}
