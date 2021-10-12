using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(!collision.gameObject.GetComponent<ObjectID>())
    //    {
    //        if (hitEffect)
    //        {
    //            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //            Destroy(effect, 5f);
    //        }
    //        Destroy(gameObject, 0.03f);
    //    }

    //    if(hitEffect)
    //    {
    //        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //        Destroy(effect, 5f);
    //    }
    //    if (collision.gameObject.GetComponent<ObjectID>().ID == 1) // == wall
    //    {
    //        collision.gameObject.GetComponent<ObjectID>().attractable = true;
    //    }
    //    if (collision.gameObject.GetComponent<ObjectID>().ID == 2) // == enemy
    //    {
    //        collision.gameObject.GetComponent<ObjectID>().attractable = true;
    //        collision.gameObject.GetComponent<EnemyBehaviour>().enabled = false;
    //        collision.gameObject.GetComponent<EnemyPath>().enabled = false;
    //    }
    //    Destroy(gameObject, 0.03f);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hitEffect)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
        if (!other.gameObject.GetComponent<ObjectID>())
        {
            return;
        }
        
        int seed = Random.Range(0, 2);
        
        if (other.gameObject.GetComponent<ObjectID>().ID == 1) // == wall
        {
            switch (seed)
            {
                case 0:
                    AudioManager.instance.Play(SoundList.PlayerBulletHit1);
                    break;
                case 1:
                    AudioManager.instance.Play(SoundList.PlayerBulletHit2);
                    break;
            }

            other.gameObject.GetComponent<ObjectFlash>().Flash();
            other.gameObject.GetComponent<ObjectFreezeState>().freezeTimer -= other.gameObject.GetComponent<ObjectFreezeState>().TakeFreezeDamage(0.25f);
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 2) // == enemy
        {
            switch (seed)
            {
                case 0:
                    AudioManager.instance.Play(SoundList.PlayerBulletHit1);
                    break;
                case 1:
                    AudioManager.instance.Play(SoundList.PlayerBulletHit2);
                    break;
            }

            other.gameObject.GetComponent<ObjectFlash>().Flash();
            other.gameObject.GetComponent<ObjectFreezeState>().freezeTimer -= other.gameObject.GetComponent<ObjectFreezeState>().TakeFreezeDamage(0.25f);
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 3) // == shield
        {
            switch (seed)
            {
                case 0:
                    AudioManager.instance.Play(SoundList.PlayerBulletHit1);
                    break;
                case 1:
                    AudioManager.instance.Play(SoundList.PlayerBulletHit2);
                    break;
            }

            other.gameObject.GetComponent<ObjectFlash>().Flash();

            other.gameObject.GetComponent<ObjectStat>().HP -= 1;
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
