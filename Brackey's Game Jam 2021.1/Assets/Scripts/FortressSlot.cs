using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressSlot : MonoBehaviour
{
    public bool hasAttached = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ObjectID>())
        {
            if (other.gameObject.GetComponent<ObjectID>().attractable && !hasAttached && transform.childCount == 0)
            {
                AudioManager.instance.Play(SoundList.PickUp);
                other.gameObject.GetComponent<ObjectID>().attracted = true;
                other.gameObject.GetComponent<ObjectID>().followingSlot = gameObject;
                other.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder += 10;
                other.gameObject.GetComponent<Collider2D>().isTrigger = true;
                //other.gameObject.AddComponent<ObjectStat>();

                if (other.gameObject.GetComponent<ObjectID>().ID == 2)
                {
                    other.gameObject.tag = "FortressObject";
                    other.gameObject.GetComponent<EnemyPath>().enabled = false;
                    other.gameObject.GetComponent<EnemyBehaviour>().enabled = true;
                    other.gameObject.GetComponent<EnemyBehaviour>().state = 1; // ally
                }
                // 9 = FortressObject
                other.gameObject.layer = 9;
                //other.gameObject.transform.position = transform.position;
                hasAttached = true;
            }
        }
    }

    public void Update()
    {
        if(transform.childCount == 0)
        {
            hasAttached = false;
        }
        else
        {
            hasAttached = true;
        }
        if(hasAttached)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (!hasAttached)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
