using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsChange", menuName = "ScriptableObjects/StatsChange", order = 7)]
public class StatsChangeScriptable : ScriptableObject, IStatsChange
{
    public bool effectGiven; //Checks if the effect has already been given
    public bool flat;
    public bool increase;
    public Enums.Stat stat;
    public string effectName;
    public double amount;
    
    public void AddEffect(Champion champion)
    {
        if (effectGiven)
        {

        }
        else
        {
            if (flat)
            {
                //flat increase
                switch (stat)
                {
                    case Enums.Stat.PHYSICALRESISTANCE:
                        if (increase)
                        {
                            champion.PhysicalResistance += amount;
                        }
                        else
                        {
                            champion.PhysicalResistance -= amount;
                        }
                        break;
                    case Enums.Stat.PHYSICALRESISTANCEIGNORE:
                        if (increase)
                        {
                            champion.PhysicalResistanceIgnore += amount;
                        }
                        else
                        {
                            champion.PhysicalResistanceIgnore -= amount;
                        }
                        break;
                    case Enums.Stat.MAGICALRESISTANCE:
                        if (increase)
                        {
                            champion.MagicalResistance += amount;
                        }
                        else
                        {
                            champion.MagicalResistance -= amount;
                        }
                        break;
                    case Enums.Stat.MAGICALRESISTANCEIGNORE:
                        if (increase)
                        {
                            champion.MagicalResistanceIgnore += amount;
                        }
                        else
                        {
                            champion.MagicalResistanceIgnore -= amount;
                        }
                        break;
                    case Enums.Stat.PHYSICALDAMAGE:
                        if (increase)
                        {
                            champion.PhysicalDamage += amount;
                        }
                        else
                        {
                            champion.PhysicalDamage -= amount;
                        }
                        break;
                    case Enums.Stat.MAGICALDAMAGE:
                        if (increase)
                        {
                            champion.MagicalDamage += amount;
                        }
                        else
                        {
                            champion.MagicalDamage -= amount;
                        }
                        break;
                    case Enums.Stat.ATTACKSPEED:
                        if (increase)
                        {
                            champion.AttackSpeed += amount;
                        }
                        else
                        {
                            champion.AttackSpeed -= amount;
                        }
                        break;
                    case Enums.Stat.MOVEMENTSPEED:
                        if (increase)
                        {
                            champion.MovementSpeed += amount;
                        }
                        else
                        {
                            champion.MovementSpeed -= amount;
                        }
                        break;
                    case Enums.Stat.HEALTH:
                        if (increase)
                        {
                            champion.CurrentHitPoints += amount;
                        }
                        else
                        {
                            champion.CurrentHitPoints -= amount;
                        }
                        break;
                    case Enums.Stat.HEALTHREGEN:
                        if (increase)
                        {
                            champion.HealthRegeneration += amount;
                        }
                        else
                        {
                            champion.HealthRegeneration -= amount;
                        }
                        break;
                    case Enums.Stat.ATTACKRANGE:
                        if (increase)
                        {
                            champion.AttackRange += amount;
                        }
                        else
                        {
                            champion.AttackRange -= amount;
                        }
                        break;
                    case Enums.Stat.RESOURCE:
                        if (increase)
                        {
                            champion.MaxManaPoints += amount;
                        }
                        else
                        {
                            champion.MaxManaPoints -= amount;
                        }
                        break;
                    case Enums.Stat.RESOURCEREGEN:
                        if (increase)
                        {
                            champion.ManaRegeneration += amount;
                        }
                        else
                        {
                            champion.ManaRegeneration -= amount;
                        }
                        break;
                    case Enums.Stat.COOLDOWN:
                        if (increase)
                        {
                            champion.CooldownReduction += amount;
                        }
                        else
                        {
                            champion.CooldownReduction -= amount;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //percent increase
                switch (stat)
                {
                    case Enums.Stat.PHYSICALRESISTANCE:
                        if (increase)
                        {
                            champion.PhysicalResistance *= (amount / 100);
                        }
                        else
                        {
                            champion.PhysicalResistance /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.PHYSICALRESISTANCEIGNORE:
                        if (increase)
                        {
                            champion.PhysicalResistanceIgnore *= (amount / 100);
                        }
                        else
                        {
                            champion.PhysicalResistanceIgnore /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.MAGICALRESISTANCE:
                        if (increase)
                        {
                            champion.MagicalResistance *= (amount / 100);
                        }
                        else
                        {
                            champion.MagicalResistance /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.MAGICALRESISTANCEIGNORE:
                        if (increase)
                        {
                            champion.MagicalResistanceIgnore *= (amount / 100);
                        }
                        else
                        {
                            champion.MagicalResistanceIgnore /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.PHYSICALDAMAGE:
                        if (increase)
                        {
                            champion.PhysicalDamage *= (amount / 100);
                        }
                        else
                        {
                            champion.PhysicalDamage /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.MAGICALDAMAGE:
                        if (increase)
                        {
                            champion.MagicalDamage *= (amount / 100);
                        }
                        else
                        {
                            champion.MagicalDamage /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.ATTACKSPEED:
                        if (increase)
                        {
                            champion.AttackSpeed *= (amount / 100);
                        }
                        else
                        {
                            champion.AttackSpeed /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.MOVEMENTSPEED:
                        if (increase)
                        {
                            champion.MovementSpeed *= (amount / 100);
                        }
                        else
                        {
                            champion.MovementSpeed /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.HEALTH:
                        if (increase)
                        {
                            champion.CurrentHitPoints *= (amount / 100);
                        }
                        else
                        {
                            champion.CurrentHitPoints /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.HEALTHREGEN:
                        if (increase)
                        {
                            champion.HealthRegeneration *= (amount / 100);
                        }
                        else
                        {
                            champion.HealthRegeneration /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.CRITCHANCE:
                        if (increase)
                        {
                            champion.CriticalStrikeChance *= ((int)amount / 100);
                        }
                        else
                        {
                            champion.CriticalStrikeChance /= ((int)amount / 100);
                        }
                        break;
                    case Enums.Stat.CRITDAMAGE:
                        if (increase)
                        {
                            champion.CriticalStrikeDamage *= ((int)amount / 100);
                        }
                        else
                        {
                            champion.CriticalStrikeDamage /= ((int)amount / 100);
                        }
                        break;
                    case Enums.Stat.TENACITY:
                        if (increase)
                        {
                            champion.DisableReductionPercent *= ((int)amount / 100);
                        }
                        else
                        {
                            champion.DisableReductionPercent /= ((int)amount / 100);
                        }
                        break;
                    case Enums.Stat.LIFESTEAL:
                        if (increase)
                        {
                            champion.LifestealPercent *= ((int)amount / 100);
                        }
                        else
                        {
                            champion.LifestealPercent /= ((int)amount / 100);
                        }
                        break;
                    case Enums.Stat.ATTACKRANGE:
                        if (increase)
                        {
                            champion.AttackRange *= (amount / 100);
                        }
                        else
                        {
                            champion.AttackRange /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.RESOURCE:
                        if (increase)
                        {
                            champion.MaxManaPoints *= (amount / 100);
                        }
                        else
                        {
                            champion.MaxManaPoints /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.RESOURCEREGEN:
                        if (increase)
                        {
                            champion.ManaRegeneration *= (amount / 100);
                        }
                        else
                        {
                            champion.ManaRegeneration /= (amount / 100);
                        }
                        break;
                    case Enums.Stat.COOLDOWN:
                        if (increase)
                        {
                            champion.CooldownReduction *= (amount / 100);
                        }
                        else
                        {
                            champion.CooldownReduction /= (amount / 100);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}