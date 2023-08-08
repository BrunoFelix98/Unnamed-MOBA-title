using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsChange", menuName = "ScriptableObjects/StatsChange", order = 7)]
public class StatsChangeScriptable : ScriptableObject, IStatsChange
{
    public Enums.Stat stat;
    public string effectName;
    public double amount;
    
    public void AddEffect(PlayerData player)
    {
        switch (stat)
            {
                case Enums.Stat.PHYSICALRESISTANCE:
                        player.PhysicalResistance += amount;
                    break;
                case Enums.Stat.PHYSICALRESISTANCEIGNORE:
                        player.PhysicalResistanceIgnore += amount;
                    break;
                case Enums.Stat.MAGICALRESISTANCE:
                        player.MagicalResistance += amount;
                    break;
                case Enums.Stat.MAGICALRESISTANCEIGNORE:
                        player.MagicalResistanceIgnore += amount;
                    break;
                case Enums.Stat.PHYSICALDAMAGE:
                        player.PhysicalDamage += amount;
                    break;
                case Enums.Stat.MAGICALDAMAGE:
                        player.MagicalDamage += amount;
                    break;
                case Enums.Stat.ATTACKSPEED:
                        player.AttackSpeed += amount;
                    break;
                case Enums.Stat.MOVEMENTSPEED:
                        player.MovementSpeed += amount;
                    break;
                case Enums.Stat.HEALTH:
                        player.CurrentHitPoints += amount;
                    break;
                case Enums.Stat.HEALTHREGEN:
                        player.HealthRegeneration += amount;
                    break;
                case Enums.Stat.CRITCHANCE:
                        player.CriticalStrikeChance += (int)amount;
                    break;
                case Enums.Stat.CRITDAMAGE:
                        player.CriticalStrikeDamage += (int)amount;
                    break;
                case Enums.Stat.TENACITY:
                        player.DisableReductionPercent += (int)amount;
                    break;
                case Enums.Stat.LIFESTEAL:
                        player.LifestealPercent += (int)amount;
                    break;
                case Enums.Stat.ATTACKRANGE:
                        player.AttackRange += amount;
                    break;
                case Enums.Stat.RESOURCE:
                        player.MaxManaPoints += amount;
                    break;
                case Enums.Stat.RESOURCEREGEN:
                        player.ManaRegeneration += amount;
                    break;
                case Enums.Stat.COOLDOWN:
                        player.CooldownReduction += amount;
                    break;
                default:
                    break;
            }
    }

    public void RemoveEffect(PlayerData player)
    {
        switch (stat)
            {
                case Enums.Stat.PHYSICALRESISTANCE:
                    player.PhysicalResistance -= amount;
                    break;
                case Enums.Stat.PHYSICALRESISTANCEIGNORE:
                    player.PhysicalResistanceIgnore -= amount;
                    break;
                case Enums.Stat.MAGICALRESISTANCE:
                    player.MagicalResistance -= amount;
                    break;
                case Enums.Stat.MAGICALRESISTANCEIGNORE:
                    player.MagicalResistanceIgnore -= amount;
                    break;
                case Enums.Stat.PHYSICALDAMAGE:
                    player.PhysicalDamage -= amount;
                    break;
                case Enums.Stat.MAGICALDAMAGE:
                    player.MagicalDamage -= amount;
                    break;
                case Enums.Stat.ATTACKSPEED:
                    player.AttackSpeed -= amount;
                    break;
                case Enums.Stat.MOVEMENTSPEED:
                    player.MovementSpeed -= amount;
                    break;
                case Enums.Stat.HEALTH:
                    player.CurrentHitPoints -= amount;
                    break;
                case Enums.Stat.HEALTHREGEN:
                    player.HealthRegeneration -= amount;
                    break;
                case Enums.Stat.CRITCHANCE:
                    player.CriticalStrikeChance -= (int)amount;
                    break;
                case Enums.Stat.CRITDAMAGE:
                    player.CriticalStrikeDamage -= (int)amount;
                    break;
                case Enums.Stat.TENACITY:
                    player.DisableReductionPercent -= (int)amount;
                    break;
                case Enums.Stat.LIFESTEAL:
                    player.LifestealPercent -= (int)amount;
                    break;
                case Enums.Stat.ATTACKRANGE:
                    player.AttackRange -= amount;
                    break;
                case Enums.Stat.RESOURCE:
                    player.MaxManaPoints -= amount;
                    break;
                case Enums.Stat.RESOURCEREGEN:
                    player.ManaRegeneration -= amount;
                    break;
                case Enums.Stat.COOLDOWN:
                    player.CooldownReduction -= amount;
                    break;
                default:
                    break;
            }
    }
}