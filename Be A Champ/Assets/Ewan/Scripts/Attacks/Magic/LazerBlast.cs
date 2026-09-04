using UnityEngine;
using System.Collections;

public class LazerBlast : BaseAttacks
{
    public LazerBlast()
    {
        attackName = "Lazer Blast";
        attackDescription = "Fires a lazer at the enemy.";
        attackDamage = 15f;
        attackCost = 5f;

    }
}

