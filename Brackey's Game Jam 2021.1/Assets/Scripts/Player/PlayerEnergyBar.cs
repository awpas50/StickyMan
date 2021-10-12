using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyBar : MonoBehaviour
{
    [SerializeField] private PlayerShooting playerShooting;

    public Image energyBarBlue;
    
    void Update()
    {
        energyBarBlue.fillAmount = (float)playerShooting.energy / (float)playerShooting.GetInitialEnergy();
    }
}
