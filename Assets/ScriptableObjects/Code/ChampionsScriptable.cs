using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Champion", menuName = "ScriptableObjects/Champion", order = 5)]
public class ChampionsScriptable : ScriptableObject
{
    public int championID;
    public int championCriticalStrikeChance;
    public int championLifestealPercent;
    public int championDisableReductionPercent;
    public bool championIsRanged;
    public string championName;
    public double championMaxHitPoints;
    public double championCurrentHitPoints;
    public double championMaxManaPoints;
    public double championMovementSpeed;
    public double championPhysicalResistance;
    public double championMagicalResistance;
    public double championPhysicalDamage;
    public double championMagicalDamage;
    public double championPhysicalResistanceIgnore;
    public double championMagicalResistanceIgnore;
    public double championCooldownReduction;
    public double championHealthRegeneration;
    public double championManaRegeneration;
    public double championCriticalStrikeDamage;
    public double championAttackRange;
    public double championAttackSpeed;
    public ChampionAbilities[] championAbilities;
}