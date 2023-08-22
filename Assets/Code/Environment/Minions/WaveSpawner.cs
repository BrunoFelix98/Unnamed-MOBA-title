using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject minionPrefab;

    public MinionScriptable[] minionScriptable;

    public string minionTag;

    public int currentMinion;

    public Transform spawnPoint;
    public float spawnInterval = 0.5f;

    public GameObject enemyBase;

    [SerializeField]
    private float spawnTimer;

    public List<GameObject> allMinionsInLaneInactive = new List<GameObject>();

    public int warriorsSpawned = 0;
    public int siegeSpawned = 0;
    public int magesSpawned = 0;

    public Material teamMat; //Will be removed later with the scriptable object

    private void Start()
    {
        spawnTimer = 40.0f;
        //currentMinion = warriorMinion;
        //minionPool = new ObjectPool<GameObject>(() => { return InstantiateMinion(currentMinion, this.transform); }, minion => minion.SetActive(true), minion => minion.SetActive(false), minion => Destroy(minion), false, 35, 42);
        StartCoroutine(SpawnWave());

        for (int i = 0; i < 49; i++)
        {
            GameObject minion = Instantiate(minionPrefab, spawnPoint);
            minion.transform.rotation = Quaternion.identity;
            minion.tag = minionTag;
            allMinionsInLaneInactive.Add(minion);
            minion.layer = 6;
            minion.GetComponent<Renderer>().material = teamMat;
            minion.SetActive(false);
        }
    }

    private void SetMinionToActive(MinionData minion, int index)
    {
        minion.gameObject.SetActive(true);

        minion.minionType = minionScriptable[index].minionType;
        minion.minionAttackSpeed = minionScriptable[index].minionAttackSpeed;
        minion.minionHitpoints = minionScriptable[index].minionHitpoints;
        minion.minionCurrentHitpoints = minionScriptable[index].minionCurrentHitpoints;
        minion.minionPhysicalResistance = minionScriptable[index].minionPhysicalResistance;
        minion.minionMagicalResistance = minionScriptable[index].minionMagicalResistance;
        minion.minionAttackDamage = minionScriptable[index].minionAttackDamage;
        minion.minionMagicalDamage = minionScriptable[index].minionMagicalDamage;
        minion.minionMovementSpeed = minionScriptable[index].minionMovementSpeed;
        minion.minionAttackRange = minionScriptable[index].minionAttackRange;
        minion.minionVisionRange = minionScriptable[index].minionVisionRange;

        minion.enemyBase = enemyBase;

        minion.selectedMinion = minionScriptable[index];

        allMinionsInLaneInactive.Remove(minion.gameObject);
    }

    public void ResetMinion(GameObject minion)
    {
        minion.transform.position = spawnPoint.position;
        allMinionsInLaneInactive.Add(minion);
        minion.SetActive(false);
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            StartCoroutine(SpawnMinionsCoroutine());
        }
    }

    IEnumerator SpawnMinionsCoroutine()
    {
        if (allMinionsInLaneInactive.Count > 6)
        {
            for (int i = 0; i < 7; i++)
            {
                yield return new WaitForSeconds(spawnInterval);

                currentMinion = GetNextMinionPrefab();

                MinionData data = allMinionsInLaneInactive[currentMinion].GetComponent<MinionData>();
                SetMinionToActive(data, currentMinion);
                UpdateSpawnedCount(data);
            }
        }
    }

    private int GetNextMinionPrefab()
    {
        if (warriorsSpawned < 3)
        {
            return 0;
        }
        else if (siegeSpawned < 1)
        {
            return 1;
        }
        else if (magesSpawned < 3)
        {
            return 2;
        }
        else
        {
            // Wave completed, reset the counters
            warriorsSpawned = 0;
            siegeSpawned = 0;
            magesSpawned = 0;
            return 0;
        }
    }

    private void UpdateSpawnedCount(MinionData minionData)
    {
        if (minionData.selectedMinion == minionScriptable[0])
        {
            warriorsSpawned++;
        }
        else if (minionData.selectedMinion == minionScriptable[1])
        {
            siegeSpawned++;
        }
        else if (minionData.selectedMinion == minionScriptable[2])
        {
            magesSpawned++;
        }
    }
}
