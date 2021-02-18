using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int HP = 20;
    public int carriedObject;
    private GameObject[] allFortressSlot;

    private void Start()
    {
        allFortressSlot = GameObject.FindGameObjectsWithTag("FortressSlot");
    }

    private void Update()
    {
        carriedObject = 0;
        for(int i = 0; i < allFortressSlot.Length; i++)
        {
            if(allFortressSlot[i].transform.childCount > 0)
            {
                carriedObject += 1;
            }
        }
    }
}
