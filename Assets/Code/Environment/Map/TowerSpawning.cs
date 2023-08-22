using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawning : MonoBehaviour
{
    public GameObject towerPrefab;

    public TowerScriptable towerScriptable;

    public string towerTag;

    public Transform spawnPoint;

    public Material teamMat; //Will be removed later with the scriptable object

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform;
        GameObject tower = Instantiate(towerPrefab, spawnPoint);
        tower.transform.rotation = Quaternion.identity;
        tower.tag = towerTag;
        tower.layer = 6;
        tower.GetComponent<Renderer>().material = teamMat;
        TowerBehaviour towerBehavior = tower.GetComponent<TowerBehaviour>();
        towerBehavior.towerData.AttackDamage = towerScriptable.towerAttackDamage;
        towerBehavior.towerData.AttackRange = towerScriptable.towerAttackRange;
        towerBehavior.towerData.AttackSpeed = towerScriptable.towerAttackSpeed;
        towerBehavior.towerData.Hitpoints = towerScriptable.towerHitpoints;
    }
}
