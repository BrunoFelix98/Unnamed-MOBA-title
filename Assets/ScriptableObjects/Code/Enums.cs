using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum MinionType
    {
        WARRIOR,
        MAGE,
        SIEGE
    }

    public enum DamageTypes
    {
        PHYSICAL,
        MAGICAL,
        TRUE
    }

    public enum MinionStates
    {
        FOLLOWLANE,
        CHASETARGET,
        ATTACKTARGET
    }

    public enum TowerType
    {
        TIER1,
        TIER2,
        TIER3,
        TIER4
    }

    public enum Stat
    {
        PHYSICALRESISTANCE,
        PHYSICALRESISTANCEIGNORE,
        MAGICALRESISTANCE,
        MAGICALRESISTANCEIGNORE,
        PHYSICALDAMAGE,
        MAGICALDAMAGE,
        ATTACKSPEED,
        MOVEMENTSPEED,
        HEALTH,
        HEALTHREGEN,
        CRITCHANCE,
        CRITDAMAGE,
        TENACITY,
        ATTACKRANGE,
        RESOURCE,
        RESOURCEREGEN,
        COOLDOWN,
        LIFESTEAL
    }
}
