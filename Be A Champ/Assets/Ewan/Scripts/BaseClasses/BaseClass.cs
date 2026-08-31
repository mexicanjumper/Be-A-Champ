using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class BaseClass 
{
    public string theName;

    public float baseHP;
    public float curHP;

    public float baseMP;
    public float curMP;

    public float baseATK;
    public float curATK;
    public float baseDEF;
    public float curDEF;

    public List <BaseAttacks> attacks = new List<BaseAttacks>();
}
