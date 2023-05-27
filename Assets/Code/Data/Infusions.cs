using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Infusions
{
    [SerializeField]
    private int infusionID;
    [SerializeField]
    private string name;
    [SerializeField]
    private double cooldown;
    [SerializeField]
    private Effect[] effects;

    public int InfusionID
    {
        get => infusionID;
        set => infusionID = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public double Cooldown
    {
        get => cooldown;
        set => cooldown = value;
    }

    public Effect[] Effects
    {
        get => effects;
        set => effects = value;
    }
    
    public Infusions(int infusionID, string name, double cooldown, Effect[] effects)
    {
        this.infusionID = infusionID;
        this.name = name;
        this.cooldown = cooldown;
        this.effects = effects;
    }
}