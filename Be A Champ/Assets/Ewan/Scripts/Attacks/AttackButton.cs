using UnityEngine;
using System.Collections;

public class AttackButton : MonoBehaviour
{
    public BaseAttacks magicAttackToPerform;

    public void CastMagicAttack()
    {
        GameObject.Find("BattleManager").GetComponent<BattelStateMacshine>().Input4(magicAttackToPerform);
    }

}
