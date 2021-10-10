using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHealthBar : MonoBehaviour
{
    public ObjectStat objectStat;

    public GameObject healthBarUI;
    public Image healthBarGrey;
    public Image healthBarRed;
    
    void Update()
    {
        HealthBarValue();
        HealthUIVisibility();
    }

    void HealthBarValue()
    {
        healthBarGrey.fillAmount = Mathf.Lerp(healthBarGrey.fillAmount, healthBarRed.fillAmount, 0.03f);

        if (objectStat.HP <= 0)
        {
            healthBarRed.fillAmount = 0;
        }
        else if (objectStat.HP >= objectStat.GetInitialHP())
        {
            healthBarRed.fillAmount = 1;
        }
        else if (objectStat.HP > 0 && objectStat.HP < objectStat.GetInitialHP())
        {
            healthBarRed.fillAmount = (float)objectStat.HP / (float)objectStat.GetInitialHP();
        }
    }

    void HealthUIVisibility()
    {
        // Enemy: health bar always shown
        // Other objects: health bar only appears when damaged;
        if(GetComponent<ObjectID>().ID == 1) // other objects
        {
            if (objectStat.HP >= objectStat.GetInitialHP())
            {
                healthBarUI.SetActive(false);
            }
            else
            {
                healthBarUI.SetActive(true);
            }
        }
        if (GetComponent<ObjectID>().ID == 2) // enemy
        {

        }
    }
    //public CanvasGroup canvasGroup;

    //void Start()
    //{
    //    canvasGroup.alpha = 0;
    //}

    //void Update()
    //{
    //    if (canvasGroup.alpha >= 0)
    //    {
    //        canvasGroup.alpha -= Time.deltaTime * 0.2f;
    //    }
    //    if (pillarProperties.HP > pillarProperties.initial_HP)
    //    {
    //        healthBar.fillAmount = 1;
    //    }
    //    else if (pillarProperties.HP < 0)
    //    {
    //        healthBar.fillAmount = 0;
    //    }
    //    else
    //    {
    //        healthBar.fillAmount = (float)pillarProperties.HP / (float)pillarProperties.initial_HP;
    //    }
    //}

    //public void SetAlpha()
    //{
    //    canvasGroup.alpha = 1;
    //}
}
