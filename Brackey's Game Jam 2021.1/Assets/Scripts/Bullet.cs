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
        if (!other.gameObject.GetComponent<ObjectID>())
        {
            return;
            //if (hitEffect)
            //{
            //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //    Destroy(effect, 5f);
            //}
            //Destroy(gameObject, 0.03f);
        }

        if (hitEffect)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 1) // == wall
        {
            other.gameObject.GetComponent<ObjectID>().attractable = true;
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 2) // == enemy
        {
            other.gameObject.GetComponent<ObjectID>().attractable = true;
            other.gameObject.GetComponent<EnemyBehaviour>().enabled = false;
            other.gameObject.GetComponent<EnemyPath>().enabled = false;
        }
        if (other.gameObject.GetComponent<ObjectID>().ID == 3) // == shield
        {
            if (hitEffect)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 5f);
            }
            Destroy(gameObject, 0.03f);
        }
        Destroy(gameObject, 0.03f);
    }
}
