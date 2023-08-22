using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAI : MonoBehaviour
{
    //Data
    public NavMeshAgent minionAgent;
    public MinionData minionData;

    //AI
    public GameObject enemyBase;
    public Transform currentTarget; //Removed on finish

    public Enums.MinionStates currentState;

    //Other teams stuff
    public List<GameObject> otherTeamsEntities = new List<GameObject>();
    public List<GameObject> potentialTargets = new List<GameObject>();

    public bool isAttacking;

    public Coroutine attackRoutine;

    // Start is called before the first frame update
    void Awake()
    {
        minionData = GetComponent<MinionData>();
        minionAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        enemyBase = minionData.enemyBase;

        minionAgent.SetDestination(enemyBase.transform.position);

        GetComponent<SphereCollider>().radius = (float)minionData.minionVisionRange;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == gameObject.tag)
        {
            return;
        }

        if (!otherTeamsEntities.Contains(other.gameObject))
        {
            otherTeamsEntities.Add(other.gameObject);
        }
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case Enums.MinionStates.FOLLOWLANE:

                RefreshLists();

                //Follow along the path
                if (potentialTargets.Count <= 0)
                {
                    currentTarget = enemyBase.transform;

                    if (minionAgent.remainingDistance < minionAgent.stoppingDistance)
                    {
                        minionAgent.SetDestination(currentTarget.position);
                    }
                }

                //Get all of the enemyTeams' minions that are in range
                foreach (GameObject otherTeamMinion in otherTeamsEntities)
                {
                    float distance = Vector3.Distance(transform.position, otherTeamMinion.transform.position);

                    if (distance <= minionData.minionVisionRange)
                    {
                        if (!potentialTargets.Contains(otherTeamMinion.gameObject))
                        {
                            potentialTargets.Add(otherTeamMinion.gameObject);
                        }
                        currentState = Enums.MinionStates.CHASETARGET;
                    }
                    else
                    {
                        potentialTargets.Remove(otherTeamMinion.gameObject);
                    }
                }

                break;
            case Enums.MinionStates.CHASETARGET:

                RefreshLists();

                // Choose the closest target
                Transform closestTarget = null;
                float closestDistance = float.MaxValue;
                foreach (GameObject potentialTarget in potentialTargets)
                {
                    float distance = Vector3.Distance(transform.position, potentialTarget.transform.position);
                    if (distance < closestDistance)
                    {
                        closestTarget = potentialTarget.transform;
                        closestDistance = distance;
                    }
                }

                currentTarget = closestTarget;

                //Check if the closest target is in attack range, if its not, follow it, if its not close enough to see, then go back to following the path
                if (closestDistance <= minionData.minionAttackRange)
                {
                    currentState = Enums.MinionStates.ATTACKTARGET;
                }
                else if (closestDistance <= minionData.minionVisionRange)
                {
                    minionAgent.SetDestination(currentTarget.transform.position);
                }
                else
                {
                    currentState = Enums.MinionStates.FOLLOWLANE;
                }

                break;
            case Enums.MinionStates.ATTACKTARGET:

                RefreshLists();

                minionAgent.ResetPath();

                if (currentTarget != null)
                {
                    if (Vector3.Distance(transform.position, currentTarget.position) > minionData.minionAttackRange)
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
                    currentState = Enums.MinionStates.CHASETARGET;
                }

                break;
            default:
                break;
        }
    }

    //Remove "missing" or "null" objects from either list
    public void RefreshLists()
    {
        otherTeamsEntities.RemoveAll(item => item == null || !item.activeInHierarchy);
        potentialTargets.RemoveAll(item => item == null || !item.activeInHierarchy);

        if (GetComponent<MinionAI>().currentTarget != null)
        {
            if (!GetComponent<MinionAI>().currentTarget.gameObject.activeInHierarchy)
            {
                GetComponent<MinionAI>().currentTarget = null;
            }
        }
    }

    private IEnumerator AttackCoroutine(Transform target)
    {
        if (target != null)
        {
            if (target.GetComponent<MinionAI>() != null)
            {
                MinionAI targetMinion = target.GetComponent<MinionAI>();

                while (targetMinion.minionData.minionCurrentHitpoints > 0)
                {
                    // Wait for the attack speed
                    yield return new WaitForSeconds(minionData.minionAttackSpeed);

                    // Perform the attack (integer based on type of damage: 0 = physical, 1 = magical, 2 = true)
                    switch (minionData.minionType)
                    {
                        case Enums.MinionType.WARRIOR:
                            if (targetMinion != null)
                            {
                                targetMinion.GetComponent<MinionHealth>().TakeDamage(targetMinion.transform, minionData.minionAttackDamage, 0);
                            }
                            break;
                        case Enums.MinionType.MAGE:
                            if (targetMinion != null)
                            {
                                targetMinion.GetComponent<MinionHealth>().TakeDamage(targetMinion.transform, minionData.minionMagicalDamage, 1);
                            }
                            break;
                        case Enums.MinionType.SIEGE:
                            if (targetMinion != null)
                            {
                                targetMinion.GetComponent<MinionHealth>().TakeDamage(targetMinion.transform, minionData.minionAttackDamage, 0);
                            }
                            break;
                        default:
                            break;
                    }

                    // Check if the target is still alive
                    if (targetMinion.minionData.minionCurrentHitpoints <= 0)
                    {
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
                    yield return new WaitForSeconds(minionData.minionAttackSpeed);

                    // Perform the attack (integer based on type of damage: 0 = physical, 1 = magical, 2 = true)
                    switch (minionData.minionType)
                    {
                        case Enums.MinionType.WARRIOR:
                            if (targetTower != null)
                            {
                                targetTower.GetComponent<TowerHealth>().TakeDamage(targetTower.transform, minionData.minionAttackDamage, 0);
                            }
                            break;
                        case Enums.MinionType.MAGE:
                            if (targetTower != null)
                            {
                                targetTower.GetComponent<TowerHealth>().TakeDamage(targetTower.transform, minionData.minionMagicalDamage, 1);
                            }
                            break;
                        case Enums.MinionType.SIEGE:
                            if (targetTower != null)
                            {
                                targetTower.GetComponent<TowerHealth>().TakeDamage(targetTower.transform, minionData.minionAttackDamage, 0);
                            }
                            break;
                        default:
                            break;
                    }

                    // Check if the target is still alive
                    if (targetTower.towerData.Hitpoints <= 0)
                    {
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
            currentState = Enums.MinionStates.CHASETARGET;
        }

        isAttacking = false;
    }

    public void OnTargetDead(Transform deadTarget)
    {
        otherTeamsEntities.Remove(deadTarget.gameObject);
        potentialTargets.Remove(deadTarget.gameObject);
        currentTarget = null;
    }
}
