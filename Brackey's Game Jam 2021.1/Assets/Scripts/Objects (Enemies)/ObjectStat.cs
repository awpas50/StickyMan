using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStat : MonoBehaviour
{
    private float HP_initial;
    public float HP = 10;

    private void Start()
    {
        HP_initial = HP;
    }

    public float GetInitialHP()
    {
        return HP_initial;
    }
}
