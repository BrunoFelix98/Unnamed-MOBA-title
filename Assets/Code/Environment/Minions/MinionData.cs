using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionData : MonoBehaviour
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

    public GameObject enemyBase;

    public MinionScriptable selectedMinion;
}
