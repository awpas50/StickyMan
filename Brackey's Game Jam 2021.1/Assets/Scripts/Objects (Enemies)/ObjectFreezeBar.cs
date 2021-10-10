using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFreezeBar : MonoBehaviour
{
    public ObjectFreezeState objectFreezeState;

    public GameObject freezeBarUI;
    public Image freezeBarGrey;
    public Image freezeBarCyan;

    void Update()
    {
        FreezeBarValue();
        FreezeUIVisibility();
    }

    public void FreezeBarValue()
    {
        freezeBarGrey.fillAmount = Mathf.Lerp(freezeBarGrey.fillAmount, freezeBarCyan.fillAmount, 0.03f);

        if (objectFreezeState.freezeTimer <= 0)
        {
            freezeBarCyan.fillAmount = 0;
        }
        else if (objectFreezeState.freezeTimer >= objectFreezeState.GetFreezeBarHealth())
        {
            freezeBarCyan.fillAmount = 1;
        }
        else if (objectFreezeState.freezeTimer > 0 && objectFreezeState.freezeTimer < objectFreezeState.GetFreezeBarHealth())
        {
            freezeBarCyan.fillAmount = (float)objectFreezeState.freezeTimer / (float)objectFreezeState.GetFreezeBarHealth();
        }
    }
    public void FreezeUIVisibility()
    {
        if (objectFreezeState.freezeTimer >= objectFreezeState.GetFreezeBarHealth())
        {
            freezeBarUI.SetActive(false);
        }
        else
        {
            freezeBarUI.SetActive(true);
        }
    }
}
