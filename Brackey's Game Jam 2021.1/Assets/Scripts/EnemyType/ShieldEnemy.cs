using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    public GameObject shield1;
    public GameObject shield2;
    private int seed;

    void Start()
    {
        seed = Random.Range(0, 2); // 0 or 1
        if(seed == 0)
        {
            shield1.SetActive(true);
            shield2.SetActive(false);
        }
        if (seed == 1)
        {
            shield1.SetActive(false);
            shield2.SetActive(true);
        }
    }

    private void Update()
    {
        // 9 = FortressObject
        if (gameObject.layer == 9) {
            if(shield1.activeSelf)
            {
                for(int i = 0; i < shield1.transform.childCount; i++)
                {
                    if(shield1.transform.childCount > 0)
                    {
                        shield1.transform.GetChild(i).gameObject.layer = 9;
                    }
                }
            }
            if (shield2.activeSelf)
            {
                for (int i = 0; i < shield2.transform.childCount; i++)
                {
                    if (shield2.transform.childCount > 0)
                    {
                        shield2.transform.GetChild(i).gameObject.layer = 9;
                    }
                }
            }
        }
    }
}
