using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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