using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int state = 0;
    private EnemyPath enemyPath;
    public GameObject[] enemyList;
    public GameObject attackTarget;
    private GameObject player;
    private Transform lastKnownPosition;
    public GameObject enemyBullet_hostile;
    public GameObject enemyBullet_friendly;

    public float bulletSpeed_initial = 5;
    private float bulletSpeed;
    public float range_initial = 10;
    private float range;

    public int damage_hostileMode = 2;
    public int damage_allyMode = 2;
    private float t = 0;
    private float t2 = 0;
    public float cd_initial = 1f; // update target position every X sec
    private float cd; 
    private float cd_updateEnemyTarget = 0.06f;

    void Start()
    {
        cd = cd_initial;
        range = range_initial;
        bulletSpeed = bulletSpeed_initial;
        enemyPath = GetComponent<EnemyPath>();
        player = GameObject.FindGameObjectWithTag("Player");
        attackTarget = player;
    }

    void AttackPlayer()
    {
        if(t >= cd && Vector3.Distance(attackTarget.transform.position, transform.position) <= range)
        {
            lastKnownPosition = attackTarget.transform;

            Vector2 dir = (lastKnownPosition.transform.position - transform.position).normalized;
            GameObject b = Instantiate(enemyBullet_hostile, transform.position, Quaternion.identity);
            b.GetComponent<EnemyBullet>().enemyRef = gameObject;
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = dir * bulletSpeed;
            b.transform.Rotate(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

            t = 0;
        }
    }

    void AttackEnemies()
    {
        if(attackTarget == player) //DEBUG
        {
            attackTarget = null;
            UpdateEnemyTargets();
        }
        if(enemyList.Length < 0) //DEBUG
        {
            attackTarget = null;
            return;
        }
        if(attackTarget == null) //DEBUG
        {
            return;
        }
        if (t >= cd && Vector3.Distance(attackTarget.transform.position, transform.position) <= range)
        {
            Vector2 dir = (attackTarget.transform.position - transform.position).normalized;
            GameObject b = Instantiate(enemyBullet_friendly, transform.position, Quaternion.identity);
            b.GetComponent<FriendlyBullet>().enemyRef = gameObject;
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = dir * bulletSpeed;
            b.transform.Rotate(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

            t = 0;
        }
    }
    
    void Update()
    {
        
        if (enemyPath.enabled)
        {
            if(attackTarget == null)
            {
                return;
            }
            if (Vector3.Distance(attackTarget.transform.position, transform.position) <= range)
            {
                enemyPath.speed = enemyPath.speed_original * 0.7f;
            }
            if (Vector3.Distance(attackTarget.transform.position, transform.position) > range)
            {
                enemyPath.speed = enemyPath.speed_original;
            }
        }
        
        t += Time.deltaTime;
        t2 += Time.deltaTime;
        if (t2 >= cd_updateEnemyTarget && state == 1)
        {
            // buff this enemy when it is attached to the player fortress
            cd = cd_initial / 2;
            range = range_initial * 1.25f;
            bulletSpeed = bulletSpeed_initial * 1.75f;
            UpdateEnemyTargets();
            t2 = 0;
        }
        if (state == 0)
        {
            AttackPlayer();
        }
        else if(state == 1)
        {
            AttackEnemies();
            if (attackTarget == null)
            {
                return;
            }
            if (attackTarget.tag != "Enemy")
            {
                attackTarget = null;
            }
        }  
    }

    void UpdateEnemyTargets()
    {
        //enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        //if (enemyList.Length == 0) {
        //    return;
        //}

        //float distance = Vector3.Distance(transform.position, enemyList[0].transform.position);
        //GameObject closestEnemy = null;
        //for (int i = 0; i < enemyList.Length; i++)
        //{
        //    if (Vector3.Distance(transform.position, enemyList[i].transform.position) < distance)
        //    {
        //        distance = Vector3.Distance(transform.position, enemyList[i].transform.position);
        //        closestEnemy = enemyList[i];
        //    }
        //}
        //if(enemyList.Length == 1)
        //{
        //    closestEnemy = enemyList[0];
        //}
        //attackTarget = closestEnemy;

        float shortestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        // find out which enemy is the nearest.
        foreach (GameObject enemy in enemyList)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= range)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestTarget = enemy;
                }
            }
        }
        if(nearestTarget.tag != "Enemy")
        {
            attackTarget = null;
        }
        if (nearestTarget != null && shortestDistance <= range)
        {
            //Lock Target
            if (attackTarget != null && Vector3.Distance(transform.position, attackTarget.transform.position) <= range)
            {
                return;
            }
            attackTarget = nearestTarget;
        }
        else
        {
            attackTarget = null;
        }
    }
}
