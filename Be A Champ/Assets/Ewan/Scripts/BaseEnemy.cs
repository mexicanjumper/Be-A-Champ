using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseEnemy 
{
    public string name;

    public enum Type
    {
        Bleed,
        Fire,
        Toxic,
    }
     
    public Type Enemytype;

    public float baseHP;
    public float curHP;

    public float baseATK;
    public float curATK;
    public float baseDEF;
    public float curDEF;
    
}
