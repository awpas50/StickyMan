using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hitEffect)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        if(collision.gameObject.GetComponent<ObjectID>().ID != 0) // != player
        {
            collision.gameObject.GetComponent<ObjectID>().attractable = true;
        }
        Destroy(gameObject, 0.03f);
    }
}
