using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public Tower towerData;

    public float lastAttackTime = 0f;
    public GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null || !currentTarget.activeInHierarchy)
        {
            // Current target is missing, search for a new one
            Collider[] enemies = Physics.OverlapSphere(transform.position, towerData.AttackRange);
            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("RedTeam") || enemy.CompareTag("BlueTeam") || enemy.CompareTag("GreenTeam") || enemy.CompareTag("YellowTeam"))
                {
                    // Check if the target is an enemy and not on the same team as the tower
                    if ((enemy.CompareTag("RedTeam") && CompareTag("BlueTeam")) ||
                        (enemy.CompareTag("RedTeam") && CompareTag("GreenTeam")) ||
                        (enemy.CompareTag("RedTeam") && CompareTag("YellowTeam")) ||
                        (enemy.CompareTag("BlueTeam") && CompareTag("RedTeam")) ||
                        (enemy.CompareTag("BlueTeam") && CompareTag("GreenTeam")) ||
                        (enemy.CompareTag("BlueTeam") && CompareTag("YellowTeam")) ||
                        (enemy.CompareTag("GreenTeam") && CompareTag("YellowTeam")) ||
                        (enemy.CompareTag("GreenTeam") && CompareTag("BlueTeam")) ||
                        (enemy.CompareTag("GreenTeam") && CompareTag("RedTeam")) ||
                        (enemy.CompareTag("YellowTeam") && CompareTag("GreenTeam")) ||
                        (enemy.CompareTag("YellowTeam") && CompareTag("BlueTeam")) ||
                        (enemy.CompareTag("YellowTeam") && CompareTag("RedTeam")))
                    {
                        // We found an enemy within range!
                        currentTarget = enemy.gameObject;
                        break;
                    }
                }
            }
        }
        else
        {
            // Current target is still valid, check if we can attack
            if (Time.time - lastAttackTime >= 1f / towerData.AttackSpeed)
            {
                // It's time to attack!
                currentTarget.GetComponent<MinionHealth>().TakeDamage(currentTarget.transform, towerData.AttackDamage, 0);
                lastAttackTime = Time.time;
            }
        }
    }

    void FixedUpdate()
    {
        if (currentTarget == null || !currentTarget.activeInHierarchy)
        {
            // Current target is missing, search for a new one
            Collider[] enemies = Physics.OverlapSphere(transform.position, towerData.AttackRange);
            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag("RedTeam") || enemy.CompareTag("BlueTeam") || enemy.CompareTag("GreenTeam") || enemy.CompareTag("YellowTeam"))
                {
                    if ((enemy.CompareTag("RedTeam") && CompareTag("BlueTeam")) ||
                        (enemy.CompareTag("RedTeam") && CompareTag("GreenTeam")) ||
                        (enemy.CompareTag("RedTeam") && CompareTag("YellowTeam")) ||
                        (enemy.CompareTag("BlueTeam") && CompareTag("RedTeam")) ||
                        (enemy.CompareTag("BlueTeam") && CompareTag("GreenTeam")) ||
                        (enemy.CompareTag("BlueTeam") && CompareTag("YellowTeam")) ||
                        (enemy.CompareTag("GreenTeam") && CompareTag("YellowTeam")) ||
                        (enemy.CompareTag("GreenTeam") && CompareTag("BlueTeam")) ||
                        (enemy.CompareTag("GreenTeam") && CompareTag("RedTeam")) ||
                        (enemy.CompareTag("YellowTeam") && CompareTag("GreenTeam")) ||
                        (enemy.CompareTag("YellowTeam") && CompareTag("BlueTeam")) ||
                        (enemy.CompareTag("YellowTeam") && CompareTag("RedTeam")))
                    {
                        currentTarget = enemy.gameObject;
                        break;
                    }
                }
            }
        }
    }
}