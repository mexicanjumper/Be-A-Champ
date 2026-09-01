using UnityEngine;
using System.Collections;

public class AttackTwo : BaseAttacks
{
    public AttackTwo()
    {
        attackName = "Slash";
        attackDescription ="A quick slash attack dealing moderate damage.";
        attackDamage = 100f;
        attackCost = 0f;
    }
}