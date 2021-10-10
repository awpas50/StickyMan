using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerStat playerStat;
    public Animator playerUIAnim;

    //public Image healthBarGrey;
    public Image healthBarGreen;

    public Color red;
    public Color yellow;
    public Color green;

    float healthPercentage;

    void Update()
    {
        
        //healthBarGrey.fillAmount = Mathf.Lerp(healthBarGrey.fillAmount, healthBarGreen.fillAmount, 0.03f);

        if (playerStat.HP <= 0)
        {
            healthBarGreen.fillAmount = 0;
        }
        else if (playerStat.HP >= playerStat.GetInitialHP())
        {
            healthBarGreen.fillAmount = 1;
        }
        else if (playerStat.HP > 0 && playerStat.HP < playerStat.GetInitialHP())
        {
            healthBarGreen.fillAmount = (float)playerStat.HP / (float)playerStat.GetInitialHP();
        }

        healthPercentage = playerStat.HP / playerStat.GetInitialHP();
        if (healthPercentage < 0.2f)
        {
            healthBarGreen.color = red;
        }
        else if (healthPercentage > 0.2f && healthPercentage <= 0.4f)
        {
            healthBarGreen.color = yellow;
        }
        else if (healthPercentage > 0.4f)
        {
            healthBarGreen.color = green;
        }
    }
}
