using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [HideInInspector] public GameObject enemyRef;
    private int damage;
    public GameObject hitEffect;

    private void Start()
    {
        damage = enemyRef.GetComponent<EnemyBehaviour>().damage_hostileMode;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.GetComponent<ObjectID>())
        {
            return;
        }

        if (hitEffect)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 0) // == player
        {
            other.gameObject.GetComponent<PlayerStat>().HP -= damage;
            if (other.gameObject.GetComponent<PlayerStat>().HP <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 1) // == wall
        {
            other.gameObject.GetComponent<ObjectStat>().HP -= damage;
            if (other.gameObject.GetComponent<ObjectStat>().HP <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 3 && other.gameObject.layer == 9) // == friendly shield
        {
            other.gameObject.GetComponent<ObjectStat>().HP -= damage;
            if (other.gameObject.GetComponent<ObjectStat>().HP <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.GetComponent<ObjectID>().attracted) // == fortressObject
        {
            other.gameObject.GetComponent<ObjectStat>().HP -= damage;
            if (other.gameObject.GetComponent<ObjectStat>().HP <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        Destroy(gameObject, 0.03f);
    }
}
