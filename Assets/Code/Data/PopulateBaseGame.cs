using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBaseGame : MonoBehaviour
{
    //effects
    public StatsChangeScriptable[] effects;

    //champions
    public ChampionsScriptable[] champions;

    //abilities
    public AbilitiesScriptable[] abilities;

    //infusions
    public InfusionsScriptable[] infusions;

    //items
    public ItemsScriptable[] items;

    //minions
    public MinionScriptable[] minions;

    //towers
    public TowerScriptable[] towers;

    public List<Effect> effectsList = new List<Effect>();
    public List<Item> itemsList = new List<Item>();
    public List<Infusions> infusionsList = new List<Infusions>();
    public List<Ability> abilitiesList = new List<Ability>();
    public List<Champion> championsList = new List<Champion>();
    public List<Minion> minionsList = new List<Minion>();
    public List<Tower> towersList = new List<Tower>();

    public static PopulateBaseGame instance;

    void Awake()
    {
        instance = this;

        PopulateAllEffects();
        PopulateAllItems();
        PopulateAllInfusions();
        PopulateAllAbilities();
        PopulateAllChampions();
        PopulateAllMinions();
        PopulateAllTowers();
    }

    void Update()
    {
        for (int i = 0; i < championsList.Count; i++)
        {
            if (championsList[i].Items.Length > 0)
            {
                for (int j = 0; j < championsList[i].Items.Length; j++)
                {
                    for (int z = 0; z < championsList[i].Items[j].itemEffects.Length; z++)
                    {
                        championsList[i].Items[j].itemEffects[z].AddEffect(championsList[i]);
                        championsList[i].Items[j].itemEffects[z].effectGiven = true;
                    }
                }
            }
        }
    }

    //-----------BELOW ARE ONLY EXAMPLES-----------//

    public void PopulateAllItems()
    {
        CreateNewItem(new Item(0, items[0].itemName, items[0].itemcooldown, items[0].itemhasActive, items[0].itemEffects));
    }

    public void PopulateAllEffects()
    {
        CreateNewEffect(new Effect(0, effects[0].effectName, true));
    }

    public void PopulateAllInfusions()
    {
        CreateNewInfusion(new Infusions(0, infusions[0].infusionName, infusions[0].infusioncooldown, infusions[0].infusionEffects));
    }

    public void PopulateAllAbilities()
    {
        CreateNewAbility(new Ability(0, abilities[0].abilityCooldown, abilities[0].abilityName, abilities[0].abilityIsPassive, abilities[0].abilityEffects, abilities[0].abilityLevel));
    }

    public void PopulateAllChampions()
    {
        CreateNewChampion(new Champion(0, champions[0].championName, champions[0].championIsRanged, champions[0].championMaxHitPoints, champions[0].championCurrentHitPoints, champions[0].championMaxManaPoints, champions[0].championMovementSpeed, champions[0].championAbilities, champions[0].championPhysicalResistance, champions[0].championMagicalResistance, champions[0].championPhysicalDamage, champions[0].championMagicalDamage, champions[0].championPhysicalResistanceIgnore, champions[0].championMagicalResistanceIgnore, champions[0].championCooldownReduction, champions[0].championHealthRegeneration, champions[0].championManaRegeneration, champions[0].championCriticalStrikeChance, champions[0].championCriticalStrikeDamage, champions[0].championLifestealPercent, champions[0].championDisableReductionPercent, champions[0].championAttackRange, champions[0].championAttackSpeed, champions[0].championItems));
    }

    public void PopulateAllMinions()
    {
        CreateNewMinion(new Minion(0, minions[0].minionType, minions[0].minionHitpoints, minions[0].minionCurrentHitpoints, minions[0].minionPhysicalResistance, minions[0].minionMagicalResistance, minions[0].minionAttackDamage, minions[0].minionMagicalDamage, minions[0].minionMovementSpeed, minions[0].minionAttackRange, minions[0].minionAttackSpeed, minions[0].minionVisionRange));
        CreateNewMinion(new Minion(1, minions[1].minionType, minions[1].minionHitpoints, minions[1].minionCurrentHitpoints, minions[1].minionPhysicalResistance, minions[1].minionMagicalResistance, minions[1].minionAttackDamage, minions[1].minionMagicalDamage, minions[1].minionMovementSpeed, minions[1].minionAttackRange, minions[1].minionAttackSpeed, minions[1].minionVisionRange));
        CreateNewMinion(new Minion(2, minions[2].minionType, minions[2].minionHitpoints, minions[2].minionCurrentHitpoints, minions[2].minionPhysicalResistance, minions[2].minionMagicalResistance, minions[2].minionAttackDamage, minions[2].minionMagicalDamage, minions[2].minionMovementSpeed, minions[2].minionAttackRange, minions[2].minionAttackSpeed, minions[2].minionVisionRange));
    }

    public void PopulateAllTowers()
    {
        CreateNewTower(new Tower(0, towers[0].towerHitpoints, towers[0].towerAttackDamage, towers[0].towerAttackSpeed, towers[0].towerAttackRange));
        CreateNewTower(new Tower(1, towers[1].towerHitpoints, towers[1].towerAttackDamage, towers[1].towerAttackSpeed, towers[1].towerAttackRange));
        CreateNewTower(new Tower(2, towers[2].towerHitpoints, towers[2].towerAttackDamage, towers[2].towerAttackSpeed, towers[2].towerAttackRange));
        CreateNewTower(new Tower(3, towers[3].towerHitpoints, towers[3].towerAttackDamage, towers[3].towerAttackSpeed, towers[3].towerAttackRange));
    }

    public void CreateNewEffect(Effect effect)
    {
        effectsList.Add(effect);
    }

    public void CreateNewItem(Item item)
    {
        itemsList.Add(item);
    }

    public void CreateNewInfusion(Infusions infusion)
    {
        infusionsList.Add(infusion);
    }

    public void CreateNewAbility(Ability ability)
    {
        abilitiesList.Add(ability);
    }

    public void CreateNewChampion(Champion champion)
    {
        championsList.Add(champion);
    }

    public void CreateNewMinion(Minion minion)
    {
        minionsList.Add(minion);
    }

    public void CreateNewTower(Tower tower)
    {
        towersList.Add(tower);
    }
}