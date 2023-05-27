using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell
{
    [SerializeField]
    private int spellID;
    [SerializeField]
    private double cooldown;
    [SerializeField]
    private string name;
    [SerializeField]
    private Effect effect;

    public int SpellID
    {
        get => spellID;
        set => spellID = value;
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

    public Effect Effects
    {
        get => effect;
        set => effect = value;
    }
    
    public Spell(int spellID, double cooldown, string name, Effect effect)
    {
        this.spellID = spellID;
        this.cooldown = cooldown;
        this.name = name;
        this.effect = effect;
    }
}