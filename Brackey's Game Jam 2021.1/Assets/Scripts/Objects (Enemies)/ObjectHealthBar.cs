using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHealthBar : MonoBehaviour
{
    public ObjectStat objectStat;

    public Image healthBarGrey;
    public Image healthBarRed;
    
    void Update()
    {
        healthBarGrey.fillAmount = Mathf.Lerp(healthBarGrey.fillAmount, healthBarRed.fillAmount, 0.03f);

        if(objectStat.HP <= 0)
        {
            healthBarRed.fillAmount = 0;
        }
        else if(objectStat.HP >= objectStat.GetInitialHP())
        {
            healthBarRed.fillAmount = 1;
        }
        else if(objectStat.HP > 0 && objectStat.HP < objectStat.GetInitialHP())
        {
            healthBarRed.fillAmount = (float)objectStat.HP / (float)objectStat.GetInitialHP();
        }
    }
}
