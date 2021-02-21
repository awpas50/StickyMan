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
    public TextMeshProUGUI lifeText;

    public GameObject teleportPoint1;
    public GameObject teleportPoint2;
    
    private float respawnTimer = 0;
    public float waitTime;

    private bool dead = false;
    private bool respawnTrigger = false;
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
        lifeText.text = "Life: " + live.ToString();

        if (player.GetComponent<PlayerStat>().HP <= 0)
        {
            dead = true;
        }
        if(dead)
        {
            respawnTimer += Time.deltaTime;
            if(respawnTimer < waitTime)
            {
                player.transform.position = teleportPoint1.transform.position;
                player.GetComponent<PlayerStat>().HP = 30;
            }
            if (respawnTimer >= waitTime)
            {
                respawnTimer = 0;
                player.transform.position = teleportPoint2.transform.position;
                dead = false;
            }
        }
    }
}
