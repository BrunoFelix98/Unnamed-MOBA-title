using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObjects/Ability", order = 6)]
public class AbilitiesScriptable : ScriptableObject
{
    public int abilityID;
    public double abilityCooldown;
    public string abilityName;
    public bool abilityIsPassive;
    public AbilityEffect[] abilityEffects;
    public int abilityLevel;
}
