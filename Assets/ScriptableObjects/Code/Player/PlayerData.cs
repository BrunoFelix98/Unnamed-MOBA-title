using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int CriticalStrikeChance;
    public int LifestealPercent;
    public int DisableReductionPercent;
    public bool IsRanged;
    public string Name;
    public double MaxHitPoints;
    public double CurrentHitPoints;
    public double MaxManaPoints;
    public double MovementSpeed;
    public double PhysicalResistance;
    public double MagicalResistance;
    public double PhysicalDamage;
    public double MagicalDamage;
    public double PhysicalResistanceIgnore;
    public double MagicalResistanceIgnore;
    public double CooldownReduction;
    public double HealthRegeneration;
    public double ManaRegeneration;
    public double CriticalStrikeDamage;
    public double AttackRange;
    public double AttackSpeed;
    public ChampionAbilities[] Abilities;
    public List<ItemsScriptable> Items = new List<ItemsScriptable>();

    public ChampionsScriptable selectedChampion;

    // Start is called before the first frame update
    void Start()
    {
        CriticalStrikeChance = selectedChampion.championCriticalStrikeChance;
        LifestealPercent = selectedChampion.championLifestealPercent;
        DisableReductionPercent = selectedChampion.championDisableReductionPercent;
        IsRanged = selectedChampion.championIsRanged;
        Name = selectedChampion.championName;
        MaxHitPoints = selectedChampion.championMaxHitPoints;
        CurrentHitPoints = selectedChampion.championCurrentHitPoints;
        MaxManaPoints = selectedChampion.championMaxManaPoints;
        MovementSpeed = selectedChampion.championMovementSpeed;
        PhysicalResistance = selectedChampion.championPhysicalResistance;
        MagicalResistance = selectedChampion.championMagicalResistance;
        PhysicalDamage = selectedChampion.championPhysicalDamage;
        MagicalDamage = selectedChampion.championMagicalDamage;
        PhysicalResistanceIgnore = selectedChampion.championPhysicalResistanceIgnore;
        MagicalResistanceIgnore = selectedChampion.championMagicalResistanceIgnore;
        CooldownReduction = selectedChampion.championCooldownReduction;
        HealthRegeneration = selectedChampion.championHealthRegeneration;
        ManaRegeneration = selectedChampion.championManaRegeneration;
        CriticalStrikeDamage = selectedChampion.championCriticalStrikeDamage;
        AttackRange = selectedChampion.championAttackRange;
        AttackSpeed = selectedChampion.championAttackSpeed;
        Abilities = selectedChampion.championAbilities;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}