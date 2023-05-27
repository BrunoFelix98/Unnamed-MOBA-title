using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionBehaviour : MonoBehaviour
{
    public NavMeshAgent minionAgent;
    public static MinionBehaviour instance;
    public Minion minionData;
    public int laneNumber;

    public Transform[] waypoints;
    public int currentWaypointID;
    public Transform currentTarget;

    public MinionStates currentState;

    [SerializeField]
    private List<GameObject> otherTeamEntities = new List<GameObject>();
    [SerializeField]
    private List<Transform> potentialTargets = new List<Transform>();

    [SerializeField]
    private bool isAttacking;

    private Coroutine attackRoutine;

    public enum MinionStates
    {
        FOLLOWLANE,
        CHASETARGET,
        ATTACKTARGET
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentWaypointID = 0; //Initialise current waypoint

        minionAgent.SetDestination(waypoints[currentWaypointID].position); //Set the first destination
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, (float)minionData.MinionVisionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, (float)minionData.MinionAttackRange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentState)
        {
            case MinionStates.FOLLOWLANE:

                RefreshLists();

                //Follow along the path
                if (potentialTargets.Count <= 0)
                {
                    if (currentWaypointID == waypoints.Length)
                    {
                        minionAgent.ResetPath(); //Reached last waypoint
                    }
                    else if (Vector3.Distance(transform.position, new Vector3(waypoints[currentWaypointID].position.x, 1, waypoints[currentWaypointID].position.z)) <= minionAgent.stoppingDistance)
                    {
                        //Reached a waypoint that isn't the last waypoint
                        currentWaypointID = (currentWaypointID + 1) % waypoints.Length;
                        minionAgent.SetDestination(new Vector3(waypoints[currentWaypointID].position.x, 1, waypoints[currentWaypointID].position.z));
                    }
                    else
                    {
                        //Resuming the path if it hasn't reached the current waypoint
                        minionAgent.SetDestination(new Vector3(waypoints[currentWaypointID].position.x, 1, waypoints[currentWaypointID].position.z));
                    }
                }

                //Get all of the enemy teams' entities

                List<GameObject> otherTeamObjects = new List<GameObject>();

                if (MinionSpawning.instance.spawning)
                {
                    GameObject[] greenTeam = GameObject.FindGameObjectsWithTag("GreenTeam");
                    GameObject[] blueTeam = GameObject.FindGameObjectsWithTag("BlueTeam");
                    GameObject[] yellowTeam = GameObject.FindGameObjectsWithTag("YellowTeam");
                    GameObject[] redTeam = GameObject.FindGameObjectsWithTag("RedTeam");

                    switch (gameObject.tag)
                    {

                        case "RedTeam":
                            for (int i = 0; i < greenTeam.Length; i++)
                            {
                                if (greenTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = greenTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(greenTeam[i]);
                                    }
                                }
                                else if (greenTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = greenTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(greenTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < blueTeam.Length; i++)
                            {
                                if (blueTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = blueTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(blueTeam[i]);
                                    }
                                }
                                else if (blueTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = blueTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(blueTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < yellowTeam.Length; i++)
                            {
                                if (yellowTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = yellowTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(yellowTeam[i]);
                                    }
                                }
                                else if (yellowTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = yellowTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(yellowTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            break;
                        case "BlueTeam":
                            for (int i = 0; i < greenTeam.Length; i++)
                            {
                                if (greenTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = greenTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(greenTeam[i]);
                                    }
                                }
                                else if (greenTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = greenTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(greenTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < redTeam.Length; i++)
                            {
                                if (redTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = redTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(redTeam[i]);
                                    }
                                }
                                else if (redTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = redTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(redTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < yellowTeam.Length; i++)
                            {
                                if (yellowTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = yellowTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(yellowTeam[i]);
                                    }
                                }
                                else if (yellowTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = yellowTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(yellowTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            break;
                        case "GreenTeam":
                            for (int i = 0; i < blueTeam.Length; i++)
                            {
                                if (blueTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = blueTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(blueTeam[i]);
                                    }
                                }
                                else if (blueTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = blueTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(blueTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < redTeam.Length; i++)
                            {
                                if (redTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = redTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(redTeam[i]);
                                    }
                                }
                                else if (redTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = redTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(redTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < yellowTeam.Length; i++)
                            {
                                if (yellowTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = yellowTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(yellowTeam[i]);
                                    }
                                }
                                else if (yellowTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = yellowTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(yellowTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            break;
                        case "YellowTeam":
                            for (int i = 0; i < blueTeam.Length; i++)
                            {
                                if (blueTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = blueTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(blueTeam[i]);
                                    }
                                }
                                else if (blueTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = blueTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(blueTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < redTeam.Length; i++)
                            {
                                if (redTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = redTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(redTeam[i]);
                                    }
                                }
                                else if (redTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = redTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(redTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int i = 0; i < greenTeam.Length; i++)
                            {
                                if (greenTeam[i].GetComponent<MinionBehaviour>() != null)
                                {
                                    // The object is a minion
                                    MinionBehaviour minion = greenTeam[i].GetComponent<MinionBehaviour>();
                                    if (minion.laneNumber == laneNumber)
                                    {
                                        // The minion is in the same lane as the tower
                                        otherTeamObjects.Add(greenTeam[i]);
                                    }
                                }
                                else if (greenTeam[i].GetComponent<TowerBehaviour>() != null)
                                {
                                    // The object is a tower
                                    TowerBehaviour tower = greenTeam[i].GetComponent<TowerBehaviour>();
                                    if (tower.laneNumber == laneNumber)
                                    {
                                        // The tower is in the same lane as the tower
                                        otherTeamObjects.Add(greenTeam[i]);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                foreach (GameObject otherTeamMinionObj in otherTeamObjects)
                {
                    if (!otherTeamEntities.Contains(otherTeamMinionObj))
                    {
                        otherTeamEntities.Add(otherTeamMinionObj);
                    }
                }

                //Get all of the enemyTeams' minions that are in range
                foreach (GameObject otherTeamMinion in otherTeamEntities)
                {
                    float distance = Vector3.Distance(transform.position, otherTeamMinion.transform.position);
                    
                    if (distance <= minionData.MinionVisionRange)
                    {
                        if (!potentialTargets.Contains(otherTeamMinion.transform))
                        {
                            potentialTargets.Add(otherTeamMinion.transform);
                        }
                        currentState = MinionStates.CHASETARGET;
                    }
                    else
                    {
                        potentialTargets.Remove(otherTeamMinion.transform);
                    }
                }

                break;
            case MinionStates.CHASETARGET:

                RefreshLists();

                // Choose the closest target
                Transform closestTarget = null;
                float closestDistance = float.MaxValue;
                foreach (Transform potentialTarget in potentialTargets)
                {
                    float distance = Vector3.Distance(transform.position, potentialTarget.position);
                    if (distance < closestDistance)
                    {
                        closestTarget = potentialTarget;
                        closestDistance = distance;
                    }
                }

                currentTarget = closestTarget;

                //Check if the closest target is in attack range, if its not, follow it, if its not close enough to see, then go back to following the path
                if (closestDistance <= minionData.MinionAttackRange)
                {
                    currentState = MinionStates.ATTACKTARGET;
                }
                else if (closestDistance <= minionData.MinionVisionRange)
                {
                    minionAgent.SetDestination(currentTarget.transform.position);
                }
                else
                {
                    currentState = MinionStates.FOLLOWLANE;
                }

                break;
            case MinionStates.ATTACKTARGET:

                RefreshLists();

                minionAgent.ResetPath();

                if (currentTarget != null)
                {
                    if (Vector3.Distance(transform.position, currentTarget.position) > minionData.MinionAttackRange)
                    {
                        minionAgent.SetDestination(currentTarget.position);
                    }

                    if (potentialTargets.Count > 0)
                    {
                        Attack(currentTarget.GetComponent<Transform>());
                    }
                }
                else
                {
                    currentState = MinionStates.CHASETARGET;
                }

                break;
            default:
                break;
        }
    }

    //Remove "missing" or "null" objects from either list
    public void RefreshLists()
    {
        otherTeamEntities.RemoveAll(item => item == null || !item.activeInHierarchy);
        potentialTargets.RemoveAll(item => item == null || !item.gameObject.activeInHierarchy);

        if (currentTarget != null)
        {
            if (!currentTarget.gameObject.activeInHierarchy)
            {
                currentTarget = null;
            }
        }
    }

    private IEnumerator AttackCoroutine(Transform target)
    {
        if (target != null)
        {
            if (target.GetComponent<MinionBehaviour>() != null)
            {
                MinionBehaviour targetMinion = target.GetComponent<MinionBehaviour>();

                while (targetMinion.minionData.MinionCurrentHitpoints > 0)
                {
                    // Wait for the attack speed
                    yield return new WaitForSeconds(minionData.MinionAttackSpeed);

                    // Perform the attack (integer based on type of damage: 0 = physical, 1 = magical, 2 = true)
                    switch (minionData.MinionType)
                    {
                        case MinionSpawning.MinionType.WARRIOR:
                            if (targetMinion != null)
                            {
                                targetMinion.GetComponent<MinionHealth>().TakeDamage(targetMinion.transform, minionData.MinionAttackDamage, 0);
                            }
                            break;
                        case MinionSpawning.MinionType.MAGE:
                            if (targetMinion != null)
                            {
                                targetMinion.GetComponent<MinionHealth>().TakeDamage(targetMinion.transform, minionData.MinionMagicalDamage, 1);
                            }
                            break;
                        case MinionSpawning.MinionType.SIEGE:
                            if (targetMinion != null)
                            {
                                targetMinion.GetComponent<MinionHealth>().TakeDamage(targetMinion.transform, minionData.MinionAttackDamage, 0);
                            }
                            break;
                        default:
                            break;
                    }

                    // Check if the target is still alive
                    if (targetMinion.minionData.MinionCurrentHitpoints <= 0)
                    {
                        RefreshLists();
                        StopAttack();
                        break;
                    }
                }

                StopAttack();
            }
            else if (target.GetComponent<TowerBehaviour>() != null)
            {
                TowerBehaviour targetTower = target.GetComponent<TowerBehaviour>();

                while (targetTower.towerData.Hitpoints > 0)
                {
                    // Wait for the attack speed
                    yield return new WaitForSeconds(minionData.MinionAttackSpeed);

                    // Perform the attack (integer based on type of damage: 0 = physical, 1 = magical, 2 = true)
                    switch (minionData.MinionType)
                    {
                        case MinionSpawning.MinionType.WARRIOR:
                            if (targetTower != null)
                            {
                                targetTower.GetComponent<TowerHealth>().TakeDamage(targetTower.transform, minionData.MinionAttackDamage, 0);
                            }
                            break;
                        case MinionSpawning.MinionType.MAGE:
                            if (targetTower != null)
                            {
                                targetTower.GetComponent<TowerHealth>().TakeDamage(targetTower.transform, minionData.MinionMagicalDamage, 1);
                            }
                            break;
                        case MinionSpawning.MinionType.SIEGE:
                            if (targetTower != null)
                            {
                                targetTower.GetComponent<TowerHealth>().TakeDamage(targetTower.transform, minionData.MinionAttackDamage, 0);
                            }
                            break;
                        default:
                            break;
                    }

                    // Check if the target is still alive
                    if (targetTower.towerData.Hitpoints <= 0)
                    {
                        RefreshLists();
                        StopAttack();
                        break;
                    }
                }

                StopAttack();
            }
        }
        else
        {
            StopAttack();
        }
    }

    private void Attack(Transform target)
    {
        if (isAttacking)
        {
            return;
        }

        isAttacking = true;

        // Start the coroutine
        attackRoutine = StartCoroutine(AttackCoroutine(target.transform));
    }

    private void StopAttack()
    {
        // Stop the coroutine and reset the flag
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            attackRoutine = null;
            currentState = MinionStates.CHASETARGET;
        }

        isAttacking = false;
    }

    public void OnTargetDead(Transform deadTarget)
    {
        otherTeamEntities.Remove(deadTarget.gameObject);
        potentialTargets.Remove(deadTarget);
        currentTarget = null;
    }
}