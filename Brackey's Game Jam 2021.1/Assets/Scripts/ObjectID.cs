using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectID : MonoBehaviour
{
    // 0: player
    // 1: wall
    // 2: enemy 1
    // 3: enemy 2
    // 4: enemy 3
    public int ID;
    public bool attractable = false;
    public bool attracted = false;
    private bool positionSetUp = false;
    public GameObject followingSlot;

    private SpriteRenderer label;
    public void Start()
    {
        label = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(attractable && !attracted)
        {
            label.enabled = true;
        }
        if(attracted)
        {
            if(!positionSetUp)
            {
                label.enabled = false;
                transform.parent = followingSlot.transform;
                transform.localPosition = new Vector3(0, 0, 0);
                positionSetUp = true;
            }
            
        }
    }
}
