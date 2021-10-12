using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFortressFireControl : MonoBehaviour
{
    public int mode = 1;
    void Update()
    {
        DetectNumberKeyInput();
        FortressObjectFireControl();
    }

    void DetectNumberKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.instance.Play(SoundList.PickUp);
            mode = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.instance.Play(SoundList.PickUp);
            mode = 2;
        }
    }
    void FortressObjectFireControl()
    {
       
        if (mode == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                if(transform.GetChild(i).transform.childCount > 0)
                {
                    if(transform.GetChild(i).GetChild(0).GetComponent<EnemyBehaviour>())
                    {
                        transform.GetChild(i).GetChild(0).GetComponent<EnemyBehaviour>().automaticFire = true;
                    }
                }
            }
        }
        if (mode == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                if (transform.GetChild(i).transform.childCount > 0)
                {
                    if (transform.GetChild(i).GetChild(0).GetComponent<EnemyBehaviour>())
                    {
                        transform.GetChild(i).GetChild(0).GetComponent<EnemyBehaviour>().automaticFire = false;
                    }
                }
            }
        }
    }
}
