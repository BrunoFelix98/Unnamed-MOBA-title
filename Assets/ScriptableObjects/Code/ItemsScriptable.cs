using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 3)]
public class ItemsScriptable : ScriptableObject
{
    public bool itemhasActive; //True if has active, false if not
    public string itemName;
    public double itemcooldown;
    public ItemEffect[] itemEffects;
}