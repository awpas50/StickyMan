﻿using System.Collections;
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
                other.gameObject.GetComponent<ObjectID>().attracted = true;
                other.gameObject.GetComponent<ObjectID>().followingSlot = gameObject;
                other.gameObject.GetComponent<Collider2D>().isTrigger = true;

                if(other.gameObject.GetComponent<ObjectID>().ID == 2)
                {
                    other.gameObject.GetComponent<EnemyPath>().enabled = false;
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
    }
}
