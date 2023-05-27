using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    [SerializeField]
    private int itemID;
    [SerializeField]
    private string name;
    [SerializeField]
    private double cooldown;
    [SerializeField]
    private bool hasActive; //True if has active, false if not
    [SerializeField]
    private Effect[] effects;

    public int ItemID
    {
        get => itemID;
        set => itemID = value;
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

    public bool HasActive
    {
        get => hasActive;
        set => hasActive = value;
    }

    public Effect[] Effects
    {
        get => effects;
        set => effects = value;
    }

    public Item(int itemID, string name, double cooldown, bool hasActive, Effect[] effects)
    {
        this.itemID = itemID;
        this.name = name;
        this.cooldown = cooldown;
        this.hasActive = hasActive;
        this.effects = effects;
    }
}