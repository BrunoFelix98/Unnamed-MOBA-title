using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Effect
{
    [SerializeField]
    private int effectID;
    [SerializeField]
    private string name;
    [SerializeField]
    private bool self; //True if it affects self, false if not

    public int EffectID
    {
        get => effectID;
        set => effectID = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public bool Self
    {
        get => self;
        set => self = value;
    }
    
    public Effect(int effectID, string name, bool self)
    {
        this.effectID = effectID;
        this.name = name;
        this.self = self;
    }
}