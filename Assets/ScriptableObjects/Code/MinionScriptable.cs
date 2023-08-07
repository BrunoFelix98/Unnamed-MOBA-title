using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Minion", menuName = "ScriptableObjects/Minion", order = 1)]
public class MinionScriptable : ScriptableObject
{
    /*public int minionID;*/
    public Enums.MinionType minionType;
    public float minionAttackSpeed;
    public double minionHitpoints;
    public double minionCurrentHitpoints;
    public double minionPhysicalResistance;
    public double minionMagicalResistance;
    public double minionAttackDamage;
    public double minionMagicalDamage;
    public double minionMovementSpeed;
    public double minionAttackRange;
    public double minionVisionRange;
}