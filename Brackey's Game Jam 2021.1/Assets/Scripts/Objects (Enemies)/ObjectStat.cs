using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStat : MonoBehaviour
{
    private int HP_initial;
    public int HP = 10;

    private void Start()
    {
        HP_initial = HP;
    }

    public int GetInitialHP()
    {
        return HP_initial;
    }
}
