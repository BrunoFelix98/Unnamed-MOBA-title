using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MinionHealth : MonoBehaviour
{
    [SerializeField] private double health;
    [SerializeField] private MinionAI itself;
    [SerializeField] private Slider healthSlider;

    void Start()
    {
        itself = GetComponent<MinionAI>();
        healthSlider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        health = itself.minionData.minionCurrentHitpoints;

        if (health <= 0)
        {
            // Notify all minions that are attacking this target
            MinionAI[] attackingMinions = FindObjectsOfType<MinionAI>();
            foreach (MinionAI attackingMinion in attackingMinions)
            {
                if (attackingMinion.currentTarget == transform)
                {
                    attackingMinion.OnTargetDead(transform);
                }
            }

            //Reset Minion
            GetComponentInParent<WaveSpawner>().ResetMinion(gameObject);
            itself.otherTeamsEntities = null;
            itself.potentialTargets = null;
            itself.currentTarget = null;
            itself.currentState = Enums.MinionStates.FOLLOWLANE;
            itself.isAttacking = false;
            itself.attackRoutine = null;
            health = 0;
        }
    }

    [Server]
    public void TakeDamage(Transform entity, double damage, int type)
    {
        if (entity.GetComponent<MinionAI>() != null)
        {
            MinionAI minionEntity = entity.GetComponent<MinionAI>();

            switch (type)
            {
                case 0: //Physical
                    if ((damage - minionEntity.minionData.minionPhysicalResistance) > 0)
                    {
                        minionEntity.minionData.minionCurrentHitpoints -= (damage - minionEntity.minionData.minionPhysicalResistance);
                        UpdateHealthBarSlider(minionEntity.minionData.minionCurrentHitpoints, minionEntity.minionData.minionHitpoints);
                    }
                    else
                    {
                        minionEntity.minionData.minionCurrentHitpoints--;
                        UpdateHealthBarSlider(minionEntity.minionData.minionCurrentHitpoints, minionEntity.minionData.minionHitpoints);
                    }
                    break;
                case 1: //Magical
                    if ((damage - minionEntity.minionData.minionMagicalResistance) > 0)
                    {
                        minionEntity.minionData.minionCurrentHitpoints -= (damage - minionEntity.minionData.minionMagicalResistance);
                        UpdateHealthBarSlider(minionEntity.minionData.minionCurrentHitpoints, minionEntity.minionData.minionHitpoints);
                    }
                    else
                    {
                        minionEntity.minionData.minionCurrentHitpoints--;
                        UpdateHealthBarSlider(minionEntity.minionData.minionCurrentHitpoints, minionEntity.minionData.minionHitpoints);
                    }
                    break;
                case 2: //True
                    minionEntity.minionData.minionCurrentHitpoints -= damage;
                    UpdateHealthBarSlider(minionEntity.minionData.minionCurrentHitpoints, minionEntity.minionData.minionHitpoints);
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

    public void UpdateHealthBarSlider(double current, double max)
    {
        healthSlider.value = (float)current / (float)max;
    }
}
