using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawning : MonoBehaviour
{
    public enum MinionType
    {
        WARRIOR,
        MAGE,
        SIEGE
    }

    //SPAWNS
    [SerializeField]
    private GameObject redToGreen;
    [SerializeField]
    private GameObject redSpawnMid;
    [SerializeField]
    private GameObject redToYellow;
    [SerializeField]
    private GameObject blueToYellow;
    [SerializeField]
    private GameObject blueSpawnMid;
    [SerializeField]
    private GameObject blueToGreen;
    [SerializeField]
    private GameObject greenToBlue;
    [SerializeField]
    private GameObject greenSpawnMid;
    [SerializeField]
    private GameObject greenToRed;
    [SerializeField]
    private GameObject yellowToRed;
    [SerializeField]
    private GameObject yellowSpawnMid;
    [SerializeField]
    private GameObject yellowToBlue;
    [SerializeField]
    private float spawnTimer;
    public bool spawning;

    //WAYPOINTS
    [SerializeField]
    private GameObject greenToRedToGreenWaypoint;
    [SerializeField]
    private GameObject greenToBlueToGreenWaypoint;
    [SerializeField]
    private GameObject yellowToRedToYellowWaypoint;
    [SerializeField]
    private GameObject yellowToBlueToYellowWaypoint;
    [SerializeField]
    private GameObject midWaypointRed;
    [SerializeField]
    private GameObject midWaypointBlue;
    [SerializeField]
    private GameObject midWaypointGreen;
    [SerializeField]
    private GameObject midWaypointYellow;

    //BASES
    [SerializeField]
    private GameObject blueBase;
    [SerializeField]
    private GameObject redBase;
    [SerializeField]
    private GameObject greenBase;
    [SerializeField]
    private GameObject yellowBase;

    //PREFABS
    [SerializeField]
    protected GameObject minionPrefab;


    //MINION COLORS *for now*
    [SerializeField]
    private Material blueMat;
    [SerializeField]
    private Material redMat;
    [SerializeField]
    private Material greenMat;
    [SerializeField]
    private Material yellowMat;

    public static MinionSpawning instance;

    //TOWERS
    public Transform[] botTowersSpawnLocations;
    public Transform[] midTowersSpawnLocations;
    public Transform[] topTowersSpawnLocations;

    public GameObject towerPrefab;

    void Awake()
    {
        instance = this;

        redToGreen = GameObject.FindGameObjectWithTag("RedToGreen");
        redSpawnMid = GameObject.FindGameObjectWithTag("RedSpawnMid");
        redToYellow = GameObject.FindGameObjectWithTag("RedToYellow");
        blueToYellow = GameObject.FindGameObjectWithTag("BlueToYellow");
        blueSpawnMid = GameObject.FindGameObjectWithTag("BlueSpawnMid");
        blueToGreen = GameObject.FindGameObjectWithTag("BlueToGreen");
        greenToBlue = GameObject.FindGameObjectWithTag("GreenToBlue");
        greenSpawnMid = GameObject.FindGameObjectWithTag("GreenSpawnMid");
        greenToRed = GameObject.FindGameObjectWithTag("GreenToRed");
        yellowToRed = GameObject.FindGameObjectWithTag("YellowToRed");
        yellowSpawnMid = GameObject.FindGameObjectWithTag("YellowSpawnMid");
        yellowToBlue = GameObject.FindGameObjectWithTag("YellowToBlue");

        greenToRedToGreenWaypoint = GameObject.FindGameObjectWithTag("GreenToRedToGreenWaypoint");
        greenToBlueToGreenWaypoint = GameObject.FindGameObjectWithTag("GreenToBlueToGreenWaypoint");
        yellowToRedToYellowWaypoint = GameObject.FindGameObjectWithTag("YellowToRedToYellowWaypoint");
        yellowToBlueToYellowWaypoint = GameObject.FindGameObjectWithTag("YellowToBlueToYellowWaypoint");

        midWaypointRed = GameObject.FindGameObjectWithTag("MidWaypointRed");
        midWaypointBlue = GameObject.FindGameObjectWithTag("MidWaypointBlue");
        midWaypointGreen = GameObject.FindGameObjectWithTag("MidWaypointGreen");
        midWaypointYellow = GameObject.FindGameObjectWithTag("MidWaypointYellow");

        blueBase = GameObject.FindGameObjectWithTag("BlueBase");
        redBase = GameObject.FindGameObjectWithTag("RedBase");
        greenBase = GameObject.FindGameObjectWithTag("GreenBase");
        yellowBase = GameObject.FindGameObjectWithTag("YellowBase");
    }

    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
        spawnTimer = 40.0f;
        StartCoroutine(SpawnWave());
        SpawnTowers();
    }

    public void SpawnTowers()
    {
        SpawnBotTowers();
        SpawnMidTowers();
        SpawnTopTowers();
    }

    public void SpawnBotTowers()
    {
        int numTowersPerTeam = botTowersSpawnLocations.Length / 4; // Assumes equal number of red, blue, green and yellow towers

        // Spawn red team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, botTowersSpawnLocations[i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.red;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 0;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "RedTeam";
        }

        // Spawn blue team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, botTowersSpawnLocations[numTowersPerTeam + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.blue;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 0;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "BlueTeam";
        }

        // Spawn green team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, botTowersSpawnLocations[(numTowersPerTeam * 2) + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.green;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 0;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "GreenTeam";
        }

        // Spawn yellow team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, botTowersSpawnLocations[(numTowersPerTeam * 3) + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.yellow;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 0;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "YellowTeam";
        }
    }

    public void SpawnMidTowers()
    {
        int numTowersPerTeam = midTowersSpawnLocations.Length / 4; // Assumes equal number of red and blue towers

        // Spawn red team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, midTowersSpawnLocations[i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.red;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 1;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "RedTeam";
        }

        // Spawn blue team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, midTowersSpawnLocations[numTowersPerTeam + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.blue;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 1;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "BlueTeam";
        }

        // Spawn green team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, midTowersSpawnLocations[(numTowersPerTeam * 2) + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.green;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 1;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "GreenTeam";
        }

        // Spawn yellow team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, midTowersSpawnLocations[(numTowersPerTeam * 3) + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.yellow;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 1;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "YellowTeam";
        }
    }

    public void SpawnTopTowers()
    {
        int numTowersPerTeam = topTowersSpawnLocations.Length / 4; // Assumes equal number of red and blue towers

        // Spawn red team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, topTowersSpawnLocations[i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.red;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 2;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "RedTeam";
        }

        // Spawn blue team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, topTowersSpawnLocations[numTowersPerTeam + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.blue;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 2;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "BlueTeam";
        }

        // Spawn green team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, topTowersSpawnLocations[(numTowersPerTeam * 2) + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.green;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 2;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "GreenTeam";
        }

        // Spawn yellow team towers in order
        for (int i = 0; i < numTowersPerTeam; i++)
        {
            GameObject tower = Instantiate(towerPrefab, topTowersSpawnLocations[(numTowersPerTeam * 3) + i]);
            tower.GetComponent<MeshRenderer>().material.color = Color.yellow;
            TowerBehaviour towerBehaviour = tower.GetComponent<TowerBehaviour>();
            towerBehaviour.laneNumber = 2;
            towerBehaviour.towerData = PopulateBaseGame.instance.towersList[i];
            tower.tag = "YellowTeam";
        }
    }

    IEnumerator SpawnMinions()
    {
        spawning = true;

        //Spawn 3 warriors
        for (int i = 0; i < 3; i++)
        {
            SpawnMinionRed(0, new Transform[] { greenToRedToGreenWaypoint.transform, greenBase.transform }, redToGreen, redMat, 0);
            SpawnMinionBlue(0, new Transform[] { yellowToBlueToYellowWaypoint.transform, yellowBase.transform }, blueToYellow, blueMat, 0);
            SpawnMinionGreen(0, new Transform[] { greenToRedToGreenWaypoint.transform, redBase.transform }, greenToRed, greenMat, 0);
            SpawnMinionYellow(0, new Transform[] { yellowToBlueToYellowWaypoint.transform, blueBase.transform }, yellowToBlue, yellowMat, 0);

            SpawnMinionRed(0, new Transform[] { midWaypointRed.transform, blueBase.transform }, redSpawnMid, redMat, 1);
            SpawnMinionBlue(0, new Transform[] { midWaypointBlue.transform, redBase.transform }, blueSpawnMid, blueMat, 1);
            SpawnMinionGreen(0, new Transform[] { midWaypointGreen.transform, yellowBase.transform }, greenSpawnMid, greenMat, 1);
            SpawnMinionYellow(0, new Transform[] { midWaypointYellow.transform, greenBase.transform }, yellowSpawnMid, yellowMat, 1);

            SpawnMinionRed(0, new Transform[] { yellowToRedToYellowWaypoint.transform, yellowBase.transform }, redToYellow, redMat, 2);
            SpawnMinionBlue(0, new Transform[] { greenToBlueToGreenWaypoint.transform, greenBase.transform }, blueToGreen, blueMat, 2);
            SpawnMinionGreen(0, new Transform[] { greenToBlueToGreenWaypoint.transform, blueBase.transform }, greenToBlue, greenMat, 2);
            SpawnMinionYellow(0, new Transform[] { yellowToRedToYellowWaypoint.transform, redBase.transform }, yellowToRed, yellowMat, 2);

            yield return new WaitForSeconds(0.5f);
        }

        //Spawn 1 siege
        SpawnMinionRed(2, new Transform[] { greenToRedToGreenWaypoint.transform, greenBase.transform }, redToGreen, redMat, 0);
        SpawnMinionBlue(2, new Transform[] { yellowToBlueToYellowWaypoint.transform, yellowBase.transform }, blueToYellow, blueMat, 0);
        SpawnMinionGreen(2, new Transform[] { greenToRedToGreenWaypoint.transform, redBase.transform }, greenToRed, greenMat, 0);
        SpawnMinionYellow(2, new Transform[] { yellowToBlueToYellowWaypoint.transform, blueBase.transform }, yellowToBlue, yellowMat, 0);

        SpawnMinionRed(2, new Transform[] { midWaypointRed.transform, blueBase.transform }, redSpawnMid, redMat, 1);
        SpawnMinionBlue(2, new Transform[] { midWaypointBlue.transform, redBase.transform }, blueSpawnMid, blueMat, 1);
        SpawnMinionGreen(2, new Transform[] { midWaypointGreen.transform, yellowBase.transform }, greenSpawnMid, greenMat, 1);
        SpawnMinionYellow(2, new Transform[] { midWaypointYellow.transform, greenBase.transform }, yellowSpawnMid, yellowMat, 1);

        SpawnMinionRed(2, new Transform[] { yellowToRedToYellowWaypoint.transform, yellowBase.transform }, redToYellow, redMat, 2);
        SpawnMinionBlue(2, new Transform[] { greenToBlueToGreenWaypoint.transform, greenBase.transform }, blueToGreen, blueMat, 2);
        SpawnMinionGreen(2, new Transform[] { greenToBlueToGreenWaypoint.transform, blueBase.transform }, greenToBlue, greenMat, 2);
        SpawnMinionYellow(2, new Transform[] { yellowToRedToYellowWaypoint.transform, redBase.transform }, yellowToRed, yellowMat, 2);

        yield return new WaitForSeconds(0.5f);

        //Spawn 3 mages
        for (int i = 0; i < 3; i++)
        {
            SpawnMinionRed(1, new Transform[] { greenToRedToGreenWaypoint.transform, greenBase.transform }, redToGreen, redMat, 0);
            SpawnMinionBlue(1, new Transform[] { yellowToBlueToYellowWaypoint.transform, yellowBase.transform }, blueToYellow, blueMat, 0);
            SpawnMinionGreen(1, new Transform[] { greenToRedToGreenWaypoint.transform, redBase.transform }, greenToRed, greenMat, 0);
            SpawnMinionYellow(1, new Transform[] { yellowToBlueToYellowWaypoint.transform, blueBase.transform }, yellowToBlue, yellowMat, 0);

            SpawnMinionRed(1, new Transform[] { midWaypointRed.transform, blueBase.transform }, redSpawnMid, redMat, 1);
            SpawnMinionBlue(1, new Transform[] { midWaypointBlue.transform, redBase.transform }, blueSpawnMid, blueMat, 1);
            SpawnMinionGreen(1, new Transform[] { midWaypointGreen.transform, yellowBase.transform }, greenSpawnMid, greenMat, 1);
            SpawnMinionYellow(1, new Transform[] { midWaypointYellow.transform, greenBase.transform }, yellowSpawnMid, yellowMat, 1);

            SpawnMinionRed(1, new Transform[] { yellowToRedToYellowWaypoint.transform, yellowBase.transform }, redToYellow, redMat, 2);
            SpawnMinionBlue(1, new Transform[] { greenToBlueToGreenWaypoint.transform, greenBase.transform }, blueToGreen, blueMat, 2);
            SpawnMinionGreen(1, new Transform[] { greenToBlueToGreenWaypoint.transform, blueBase.transform }, greenToBlue, greenMat, 2);
            SpawnMinionYellow(1, new Transform[] { yellowToRedToYellowWaypoint.transform, redBase.transform }, yellowToRed, yellowMat, 2);

            yield return new WaitForSeconds(0.5f);
        }

        spawning = false;
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            StartCoroutine(SpawnMinions());

            yield return new WaitForSeconds(spawnTimer);
        }
    }

    public void SpawnMinionRed(int type, Transform[] waypoints, GameObject spawnPoint, Material material, int laneNumber)
    {
        GameObject minion;

        minion = Instantiate(minionPrefab, new Vector3(spawnPoint.transform.position.x, 1, spawnPoint.transform.position.z), Quaternion.identity);
        minion.GetComponent<MeshRenderer>().material = material;
        minion.tag = "RedTeam";
        MinionBehaviour redminionAgent = minion.GetComponent<MinionBehaviour>();
        redminionAgent.laneNumber = laneNumber;
        redminionAgent.minionData = PopulateBaseGame.instance.minionsList[type];
        redminionAgent.waypoints = waypoints;
    }

    public void SpawnMinionBlue(int type, Transform[] waypoints, GameObject alliedBase, Material material, int laneNumber)
    {
        GameObject minion;

        minion = Instantiate(minionPrefab, new Vector3(alliedBase.transform.position.x, 1, alliedBase.transform.position.z), Quaternion.identity);
        minion.GetComponent<MeshRenderer>().material = material;
        minion.tag = "BlueTeam";
        MinionBehaviour blueMinionAgent = minion.GetComponent<MinionBehaviour>();
        blueMinionAgent.laneNumber = laneNumber;
        blueMinionAgent.minionData = PopulateBaseGame.instance.minionsList[type];
        blueMinionAgent.waypoints = waypoints;
    }

    public void SpawnMinionGreen(int type, Transform[] waypoints, GameObject alliedBase, Material material, int laneNumber)
    {
        GameObject minion;

        minion = Instantiate(minionPrefab, new Vector3(alliedBase.transform.position.x, 1, alliedBase.transform.position.z), Quaternion.identity);
        minion.GetComponent<MeshRenderer>().material = material;
        minion.tag = "GreenTeam";
        MinionBehaviour greenMinionAgent = minion.GetComponent<MinionBehaviour>();
        greenMinionAgent.laneNumber = laneNumber;
        greenMinionAgent.minionData = PopulateBaseGame.instance.minionsList[type];
        greenMinionAgent.waypoints = waypoints;
    }

    public void SpawnMinionYellow(int type, Transform[] waypoints, GameObject alliedBase, Material material, int laneNumber)
    {
        GameObject minion;

        minion = Instantiate(minionPrefab, new Vector3(alliedBase.transform.position.x, 1, alliedBase.transform.position.z), Quaternion.identity);
        minion.GetComponent<MeshRenderer>().material = material;
        minion.tag = "YellowTeam";
        MinionBehaviour yellowMinionAgent = minion.GetComponent<MinionBehaviour>();
        yellowMinionAgent.laneNumber = laneNumber;
        yellowMinionAgent.minionData = PopulateBaseGame.instance.minionsList[type];
        yellowMinionAgent.waypoints = waypoints;
    }
}