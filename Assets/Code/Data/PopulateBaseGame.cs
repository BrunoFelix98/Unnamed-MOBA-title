using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBaseGame : MonoBehaviour
{
    public enum DamageTypes
    {
        PHYSICAL,
        MAGICAL,
        TRUE
    }

    public List<Effect> effectsList = new List<Effect>();
    public List<Item> itemsList = new List<Item>();
    public List<Infusions> infusionsList = new List<Infusions>();
    public List<Ability> abilitiesList = new List<Ability>();
    public List<Champion> championsList = new List<Champion>();
    public List<Minion> minionsList = new List<Minion>();
    public List<Tower> towersList = new List<Tower>();

    public static PopulateBaseGame instance;

    //-----------BELOW ARE ONLY EXAMPLES-----------//

    public static class EffectNames
    {
        public static readonly string BETTERLIFESTEAL = "Better Lifesteal";
    }

    public static class ItemNames
    {
        public static readonly string BLOODTHIRSTER = "Bloodthirster";
    }

    public static class InfusionNames
    {
        public static readonly string LIFESTEAL = "Lifesteal";
    }

    public static class AbilityNames
    {
        public static readonly string ENRAGED = "Enraged";
    }

    public static class ChampionNames
    {
        public static readonly string OLAF = "Olaf";
    }

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

    //-----------BELOW ARE ONLY EXAMPLES-----------//

    public void PopulateAllItems()
    {
        //                     ID name                     cd hasActive?   effects
        CreateNewItem(new Item(0, ItemNames.BLOODTHIRSTER, 0, false,       new[] {effectsList[0]}));
    }

    public void PopulateAllEffects()
    {
        //                         ID name                         self?
        CreateNewEffect(new Effect(0, EffectNames.BETTERLIFESTEAL, true));
    }

    public void PopulateAllInfusions()
    {
        //                              ID name                     cd effects
        CreateNewInfusion(new Infusions(0, InfusionNames.LIFESTEAL, 0, new[] { effectsList[0] }));
    }

    public void PopulateAllAbilities()
    {
        //                           ID cd name                  passive?   effects                   lvl
        CreateNewAbility(new Ability(0, 5, AbilityNames.ENRAGED, true,      new[] { effectsList[0] }, 0));
    }

    public void PopulateAllChampions()
    {
        //                             ID type                ranged?   maxhealth   maxmana     movspd      abilities                   Presist     Mresist     Pdmg    Mdmg    PresistIgnore   MresistIgnore   cdr     Hregen      Mregen      critchange%     critdmg%    lifesteal%      tenacity%   Arange
        CreateNewChampion(new Champion(0, ChampionNames.OLAF, false,    500.0,      300.0,      3.5,        new[] { abilitiesList[0] }, 20.0,       15.0,       50.0,   0.0,    0.0,            0.0,            0.0,    3.0,        1.5,        0,              200.0,      10,             0,          1.0));
    }

    public void PopulateAllMinions()
    {
        //                         ID type                               maxhealth  Presist     Mresist     Pdmg    Mdmg    Movspd  Arange      Aspd       vrange  currenthealth
        CreateNewMinion(new Minion(0, MinionSpawning.MinionType.WARRIOR, 200.0,     5.0,        5.0,        20.0,   0.0,    3.5,    1.0,        1f,        12.0,   200.0));
        CreateNewMinion(new Minion(1, MinionSpawning.MinionType.MAGE,    150.0,     0.0,        0.0,        0.0,    30.0,   3.5,    7.0,       1.5f,       12.0,   150.0));
        CreateNewMinion(new Minion(2, MinionSpawning.MinionType.SIEGE,   500.0,     15.0,       15.0,       50.0,   0.0,    3.5,    7.0,       1.75f,      12.0,   500.0));
    }

    public void PopulateAllTowers()
    {
        //                       ID hitpoints   Admg   Aspd  Arange
        CreateNewTower(new Tower(0, 5000.0,     150.0, 1.5f, 11.0f));
        CreateNewTower(new Tower(1, 5000.0,     200.0, 1.5f, 10.0f));
        CreateNewTower(new Tower(2, 5000.0,     400.0, 1.5f, 9.0f));
        CreateNewTower(new Tower(3, 5000.0,     500.0, 1.5f, 7.5f));
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