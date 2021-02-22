using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
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
        int seed = Random.Range(0, 2);

        if (!other.gameObject.GetComponent<ObjectID>())
        {
            return;
        }
        if (other.gameObject.GetComponent<ObjectID>().ID != 0)
        {
            if (hitEffect)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 5f);
            }
            Destroy(gameObject, 0.03f);
        }

        if (hitEffect)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 1) // == wall
        {
            other.gameObject.GetComponent<ObjectStat>().HP -= damage;
            if (other.gameObject.GetComponent<ObjectStat>().HP <= 0)
            {
                if (seed == 0)
                    AudioManager.instance.Play(SoundList.Dead1);
                else if (seed == 1)
                    AudioManager.instance.Play(SoundList.Dead2);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 2) // == enemy
        {

            other.gameObject.GetComponent<ObjectStat>().HP -= damage;
            if (other.gameObject.GetComponent<ObjectStat>().HP <= 0)
            {
                if (seed == 0)
                    AudioManager.instance.Play(SoundList.Dead1);
                else if (seed == 1)
                    AudioManager.instance.Play(SoundList.Dead2);
                Destroy(other.gameObject);
            }
        }
        Destroy(gameObject, 0.03f);
    }
}
