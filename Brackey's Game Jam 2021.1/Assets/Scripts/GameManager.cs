using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public static bool gameEnded = false;
    public int waves = 1;
    public int TotalWave = 12;
    public int live = 20;
    
    private GameObject player;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI waveText;

    void Awake()
    {
        //debug
        if (i != null)
        {
            Debug.LogError("More than one GameManager in scene");
            return;
        }
        i = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerHealthText.text = "Player HP: " + player.GetComponent<PlayerStat>().HP.ToString();
        waveText.text = "Wave: " + waves.ToString();
    }
}
