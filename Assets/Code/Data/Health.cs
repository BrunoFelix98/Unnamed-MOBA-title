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
        if (entity.GetComponent<MinionBehaviour>() != null)
        {
            MinionBehaviour minionEntity = entity.GetComponent<MinionBehaviour>();

            switch (type)
            {
                case 0: //Physical
                    if ((damage - minionEntity.minionData.MinionPhysicalResistance) > 0)
                    {
                        minionEntity.minionData.MinionCurrentHitpoints -= (damage - minionEntity.minionData.MinionPhysicalResistance);
                    }
                    else
                    {
                        minionEntity.minionData.MinionCurrentHitpoints--;
                    }
                    break;
                case 1: //Magical
                    if ((damage - minionEntity.minionData.MinionMagicalResistance) > 0)
                    {
                        minionEntity.minionData.MinionCurrentHitpoints -= (damage - minionEntity.minionData.MinionMagicalResistance);
                    }
                    else
                    {
                        minionEntity.minionData.MinionCurrentHitpoints--;
                    }
                    break;
                case 2: //True
                    minionEntity.minionData.MinionCurrentHitpoints -= damage;
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