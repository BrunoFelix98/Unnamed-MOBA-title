using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Infusions", menuName = "ScriptableObjects/Infusions", order = 4)]
public class InfusionsScriptable : ScriptableObject
{
    public string infusionName;
    public double infusioncooldown;
    public InfusionsEffect[] infusionEffects;
}