using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Ability
{
    [SerializeField]
    private int abilityID;
    [SerializeField]
    private double cooldown;
    [SerializeField]
    private string name;
    [SerializeField]
    private bool passive; //True if passive, false if not
    [SerializeField]
    private Effect[] effects;
    [SerializeField]
    private int level;

    public int AbilityID
    {
        get => abilityID;
        set => abilityID = value;
    }

    public double Cooldown
    {
        get => cooldown;
        set => cooldown = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public bool Passive
    {
        get => passive;
        set => passive = value;
    }

    public Effect[] Effects
    {
        get => effects;
        set => effects = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public Ability(int abilityID, double cooldown, string name, bool passive, Effect[] effects, int level)
    {
        this.abilityID = abilityID;
        this.cooldown = cooldown;
        this.name = name;
        this.passive = passive;
        this.effects = effects;
        this.level = level;
    }
}