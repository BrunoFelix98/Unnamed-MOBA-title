using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Minion
{
    [SerializeField]
    private int minionID;
    [SerializeField]
    private MinionSpawning.MinionType minionType;
    [SerializeField]
    private double minionHitpoints;
    [SerializeField]
    private double minionCurrentHitpoints;
    [SerializeField]
    private double minionPhysicalResistance;
    [SerializeField]
    private double minionMagicalResistance;
    [SerializeField]
    private double minionAttackDamage;
    [SerializeField]
    private double minionMagicalDamage;
    [SerializeField]
    private double minionMovementSpeed;
    [SerializeField]
    private double minionAttackRange;
    [SerializeField]
    private float minionAttackSpeed;
    [SerializeField]
    private double minionVisionRange;

    public MinionSpawning.MinionType MinionType
    {
        get => minionType; 
        set => minionType = value;
    }

    public int MinionID
    {
        get => minionID;
        set => minionID = value;
    }

    public double MinionHitpoints
    {
        get => minionHitpoints;
        set => minionHitpoints = value;
    }

    public double MinionPhysicalResistance
    {
        get => minionPhysicalResistance;
        set => minionPhysicalResistance = value;
    }

    public double MinionMagicalResistance
    {
        get => minionMagicalResistance;
        set => minionMagicalResistance = value;
    }

    public double MinionAttackDamage
    {
        get => minionAttackDamage;
        set => minionAttackDamage = value;
    }

    public double MinionMagicalDamage
    {
        get => minionMagicalDamage;
        set => minionMagicalDamage = value;
    }

    public double MinionMovementSpeed
    {
        get => minionMovementSpeed;
        set => minionMovementSpeed = value;
    }

    public double MinionAttackRange
    {
        get => minionAttackRange;
        set => minionAttackRange = value;
    }

    public float MinionAttackSpeed
    {
        get => minionAttackSpeed;
        set => minionAttackSpeed = value;
    }

    public double MinionVisionRange
    {
        get => minionVisionRange;
        set => minionVisionRange = value;
    }

    public double MinionCurrentHitpoints
    {
        get => minionCurrentHitpoints;
        set => minionCurrentHitpoints = value;
    }

    public Minion(int minionID, MinionSpawning.MinionType minionType, double minionHitpoints, double minionPhysicalResistance, double minionMagicalResistance, double minionAttackDamage, double minionMagicalDamage, double minionMovementSpeed, double minionAttackRange, float minionAttackSpeed, double minionVisionRange, double minionCurrentHitpoints)
    {
        this.minionID = minionID;
        this.minionType = minionType;
        this.minionHitpoints = minionHitpoints;
        this.minionPhysicalResistance = minionPhysicalResistance;
        this.minionMagicalResistance = minionMagicalResistance;
        this.minionAttackDamage = minionAttackDamage;
        this.minionMagicalDamage = minionMagicalDamage;
        this.minionMovementSpeed = minionMovementSpeed;
        this.minionAttackRange = minionAttackRange;
        this.minionAttackSpeed = minionAttackSpeed;
        this.minionVisionRange = minionVisionRange;
        this.minionCurrentHitpoints = minionCurrentHitpoints;
    }
}