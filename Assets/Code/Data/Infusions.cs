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
    private StatsChangeScriptable[] effects;

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

    public StatsChangeScriptable[] Effects
    {
        get => effects;
        set => effects = value;
    }
    
    public Infusions(int infusionID, string name, double cooldown, StatsChangeScriptable[] effects)
    {
        this.infusionID = infusionID;
        this.name = name;
        this.cooldown = cooldown;
        this.effects = effects;
    }
}