using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Tower", order = 2)]
public class TowerScriptable : ScriptableObject
{
    /*public int towerID;*/
    public Enums.TowerType towerTier;
    public float towerAttackRange;
    public float towerAttackSpeed;
    public double towerHitpoints;
    public double towerAttackDamage;
}
