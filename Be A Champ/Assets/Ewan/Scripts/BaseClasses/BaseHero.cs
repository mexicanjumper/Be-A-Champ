using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseHero: BaseClass
{

    public int stamina;
    public int intellect;
    public int agility;
    public int dexterity;

    public List <BaseAttacks> MagicAttack = new List<BaseAttacks>();

}
