using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseAttacks : MonoBehaviour
{
    public string attackName;//name of the attack
    public string attackDescription;//tells you what the attack does
    public float attackDamage;//base damage
    public float attackCost;//MannaCost
}
