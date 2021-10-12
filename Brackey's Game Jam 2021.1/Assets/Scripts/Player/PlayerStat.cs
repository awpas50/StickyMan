using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private float HP_initial;
    public float HP = 20;
    public int carriedObject;
    private GameObject[] allFortressSlot;
    private GameObject playerFortress;

    private void Start()
    {
        HP_initial = HP;

        allFortressSlot = GameObject.FindGameObjectsWithTag("FortressSlot");
        playerFortress = GameObject.FindGameObjectWithTag("PlayerFortress");
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

    public float GetInitialHP()
    {
        return HP_initial;
    }
}
