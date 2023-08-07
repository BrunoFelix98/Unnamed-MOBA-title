using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Champion
{
    [SerializeField]
    private int championID;
    [SerializeField]
    private string name;
    [SerializeField]
    private bool ranged; //True if ranged, false if not
    [SerializeField]
    private double maxHitPoints;
    [SerializeField]
    private double maxManaPoints;
    [SerializeField]
    private double movementSpeed;
    [SerializeField]
    private AbilitiesScriptable[] abilities;
    [SerializeField]
    private double physicalResistance; //Treat it as armor
    [SerializeField]
    private double magicalResistance; //Treat it as "magic resist"
    [SerializeField]
    private double physicalDamage;
    [SerializeField]
    private double magicalDamage;
    [SerializeField]
    private double physicalResistanceIgnore; //Treat it as armor penetration or "lethality"
    [SerializeField]
    private double magicalResistanceIgnore; //Treat it as magic penetration
    [SerializeField]
    private double cooldownReduction; //Reduces the cooldown of abilities
    [SerializeField]
    private double healthRegeneration;
    [SerializeField]
    private double manaRegeneration;
    [SerializeField]
    private int criticalStrikeChance;
    [SerializeField]
    private double criticalStrikeDamage;
    [SerializeField]
    private int lifestealPercent; //Affects abilities AND auto attacks
    [SerializeField]
    private int disableReductionPercent; //Treat it as "tenacity"
    [SerializeField]
    private double attackRange;

    public int ChampionID
    {
        get => championID;
        set => championID = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public bool Ranged
    {
        get => ranged;
        set => ranged = value;
    }

    public double MaxHitPoints
    {
        get => maxHitPoints;
        set => maxHitPoints = value;
    }

    public double MaxManaPoints
    {
        get => maxManaPoints;
        set => maxManaPoints = value;
    }

    public double MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }

    public AbilitiesScriptable[] Abilities
    {
        get => abilities;
        set => abilities = value;
    }

    public double PhysicalResistance
    {
        get => physicalResistance;
        set => physicalResistance = value;
    }

    public double MagicalResistance
    {
        get => magicalResistance;
        set => magicalResistance = value;
    }

    public double PhysicalDamage
    {
        get => physicalDamage;
        set => physicalDamage = value;
    }

    public double MagicalDamage
    {
        get => magicalDamage;
        set => magicalDamage = value;
    }

    public double PhysicalResistanceIgnore
    { 
       get => physicalResistanceIgnore;
       set => physicalResistanceIgnore = value;
    }

    public double MagicalResistanceIgnore
    {
        get => magicalResistanceIgnore;
        set => magicalResistanceIgnore = value;
    }

    public double CooldownReduction
    {
        get => cooldownReduction;
        set => cooldownReduction = value;
    }

    public double HealthRegeneration
    {
        get => healthRegeneration;
        set => healthRegeneration = value;
    }

    public double ManaRegeneration
    {
        get => manaRegeneration;
        set => manaRegeneration = value;
    }

    public int CriticalStrikeChance
    {
        get => criticalStrikeChance;
        set => criticalStrikeChance = value;
    }

    public double CriticalStrikeDamage
    {
        get => criticalStrikeDamage;
        set => criticalStrikeDamage = value;
    }

    public int LifestealPercent
    {
        get => lifestealPercent;
        set => lifestealPercent = value;
    }

    public int DisableReductionPercent
    {
        get => disableReductionPercent;
        set => disableReductionPercent = value;
    }

    public double AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }

    public Champion(int championID, string name, bool ranged, double maxHitPoints, double maxManaPoints, double movementSpeed, AbilitiesScriptable[] abilities, double physicalResistance, double magicalResistance, double physicalDamage, double magicalDamage, double physicalResistanceIgnore, double magicalResistanceIgnore, double cooldownReduction, double healthRegeneration, double manaRegeneration, int criticalStrikeChance, double criticalStrikeDamage, int lifestealPercent, int disableReductionPercent, double attackRange)
    {
        this.championID = championID;
        this.name = name;
        this.ranged = ranged;
        this.maxHitPoints = maxHitPoints;
        this.maxManaPoints = maxManaPoints;
        this.movementSpeed = movementSpeed;
        this.abilities = abilities;
        this.physicalResistance = physicalResistance;
        this.magicalResistance = magicalResistance;
        this.physicalDamage = physicalDamage;
        this.magicalDamage = magicalDamage;
        this.physicalResistanceIgnore = physicalResistanceIgnore;
        this.magicalResistanceIgnore = magicalResistanceIgnore;
        this.cooldownReduction = cooldownReduction;
        this.healthRegeneration = healthRegeneration;
        this.manaRegeneration = manaRegeneration;
        this.criticalStrikeChance = criticalStrikeChance;
        this.criticalStrikeDamage = criticalStrikeDamage;
        this.lifestealPercent = lifestealPercent;
        this.disableReductionPercent = disableReductionPercent;
        this.attackRange = attackRange;
    }
}