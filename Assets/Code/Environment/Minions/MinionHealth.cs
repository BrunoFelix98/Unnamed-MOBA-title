using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MinionHealth : MonoBehaviour
{
    public double health;
    public MinionBehaviour itself;

    void Start()
    {
        itself = GetComponent<MinionBehaviour>();
    }

    void Update()
    {
        health = itself.minionData.minionCurrentHitpoints;

        if (health <= 0)
        {
            // Notify all minions that are attacking this target
            MinionBehaviour[] attackingMinions = FindObjectsOfType<MinionBehaviour>();
            foreach (MinionBehaviour attackingMinion in attackingMinions)
            {
                if (attackingMinion.currentTarget == transform)
                {
                    attackingMinion.OnTargetDead(transform);
                }
            }

            // Destroy the target game object
            Destroy(gameObject);
        }
    }

    [Server]
    public void TakeDamage(Transform entity, double damage, int type)
    {
        if (entity.GetComponent<MinionBehaviour>() != null)
        {
            MinionBehaviour minionEntity = entity.GetComponent<MinionBehaviour>();

            switch (type)
            {
                case 0: //Physical
                    if ((damage - minionEntity.minionData.minionPhysicalResistance) > 0)
                    {
                        minionEntity.minionData.minionCurrentHitpoints -= (damage - minionEntity.minionData.minionPhysicalResistance);
                    }
                    else
                    {
                        minionEntity.minionData.minionCurrentHitpoints--;
                    }
                    break;
                case 1: //Magical
                    if ((damage - minionEntity.minionData.minionMagicalResistance) > 0)
                    {
                        minionEntity.minionData.minionCurrentHitpoints -= (damage - minionEntity.minionData.minionMagicalResistance);
                    }
                    else
                    {
                        minionEntity.minionData.minionCurrentHitpoints--;
                    }
                    break;
                case 2: //True
                    minionEntity.minionData.minionCurrentHitpoints -= damage;
                    break;
                default:
                    break;
            }
        }
        else if(entity.GetComponent<TowerBehaviour>() != null)
        {
            TowerBehaviour towerEntity = entity.GetComponent<TowerBehaviour>();

            towerEntity.towerData.Hitpoints -= damage;
        }
    }
}
