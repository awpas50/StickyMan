using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tips : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI info;

    private float t = 0;
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t <= 12)
        {
            title.text = "Tips";
            info.text = "You are a sticky man. YOU got one weapon with long cd, but you can literally shoot anything. i repeat, anthing.";
        }
        else if(t >= 12 && GameManager.i.waves == 1)
        {
            title.text = "Infected washing machine (OCC-2620)";
            info.text = "Seems like your roomates left the clothes inside the washing machine a few day and it triggered them.";
        }
        else if(GameManager.i.waves == 2)
        {
            title.text = "Tips";
            info.text = "Your color gets darker when you are recharging your ammo.";
        }
        else if(GameManager.i.waves == 3)
        {
            title.text = "Infected fridge (OCC-683)";
            info.text = "Your roomates left some big macs inside the fridge and they don't accept it. You have to rely on the infected object's power.";
        }
        else if (GameManager.i.waves == 4)
        {
            title.text = "Tips";
            info.text = "Obstacles in the map has much more hitpoints than the infected objects. Use them wisely.";
        }
        else if(GameManager.i.waves == 5)
        {
            title.text = "Infected oven (OCC-3049)";
            info.text = "Your roomates forgot to turn off the oven and it burned the food inside. That's why the are running fast.";
        }
        else if (GameManager.i.waves == 6)
        {
            title.text = "Tips";
            info.text = "Your weapon has a tiny splash effect. You can hit multiple targets if enemies are sticking together.";
        }
        else if(GameManager.i.waves == 8)
        {
            title.text = "Infected coffee machine (OCC-294)";
            info.text = "Your roomates finally did a good thing so the coffee machine is trying to make numerous cups of coffee to reward you (no, they are enemies).";
        }
        else
        {
            title.text = "";
            info.text = "";
        }
    }
}
