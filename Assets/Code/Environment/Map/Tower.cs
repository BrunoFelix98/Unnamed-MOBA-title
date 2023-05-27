using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Tower
{
    [SerializeField]
    private int id; //type of tower
    [SerializeField]
    private double hitpoints;
    [SerializeField]
    private double attackDamage;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float attackRange;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public double Hitpoints
    {
        get => hitpoints;
        set => hitpoints = value;
    }

    public double AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    public float AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }

    public Tower(int id, double hitpoints, double attackDamage, float attackSpeed, float attackRange)
    {
        this.id = id;
        this.hitpoints = hitpoints;
        this.attackDamage = attackDamage;
        this.attackSpeed = attackSpeed;
        this.attackRange = attackRange;
    }
}
