using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public static bool gameEnded = false;
    public static bool win = false;
    public static bool lose = false;
    public int waves = 1;
    public int TotalWave = 11;
    public int live = 20;
    
    private GameObject player;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI lifeText;
    public GameObject beginning_panel;
    public GameObject death_panel;
    public GameObject win_panel;
    public GameObject lose_panel;

    public GameObject teleportPoint1;
    public GameObject teleportPoint2;
    
    private float respawnTimer = 0;
    public float waitTime;

    private bool dead = false;
    private bool respawnTrigger = false;

    private float t = 0;
    private float t11 = 0;
    private int[] enemyNumOnEachWave = new int[11] { 5, 5, 6, 8, 8, 8, 12, 10, 10, 10, 20 };

    private GameObject[] enemies;
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
        win = false;
        lose = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if(!player.GetComponent<PlayerMovement>().enabled)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            
        }
        if(!player.GetComponent<PlayerShooting>().enabled)
        {
            player.GetComponent<PlayerShooting>().enabled = false;
        }
        beginning_panel.SetActive(true);
        win_panel.SetActive(false);
        lose_panel.SetActive(false);
        StartCoroutine(CountWaves());
    }

    void Update()
    {
        t += Time.deltaTime;
        if(t >= 12)
        {
            beginning_panel.SetActive(false);
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        playerHealthText.text = "HP " + player.GetComponent<PlayerStat>().HP.ToString();
        waveText.text = "Wave " + waves.ToString() + "/11";
        lifeText.text = "Lives " + live.ToString();

        if (player.GetComponent<PlayerStat>().HP <= 0)
        {
            dead = true;
        }
        if(dead)
        {
            respawnTimer += Time.deltaTime;
            death_panel.SetActive(true);
            if (respawnTimer < waitTime)
            {
                player.transform.position = teleportPoint1.transform.position;
                player.GetComponent<PlayerStat>().HP = 30;
            }
            if (respawnTimer >= waitTime)
            {
                respawnTimer = 0;
                player.transform.position = teleportPoint2.transform.position;
                death_panel.SetActive(false);
                dead = false;
            }
        }

        if(waves == 11)
        {
            t11 += Time.deltaTime;
        }
        // Win
        if(waves == 11 && enemies.Length == 0 && t11 >= 10)
        {
            gameEnded = true;
            win = true;
        }
        if (live == 0)
        {
            lose = true;
        }

        if(lose)
        {
            lose_panel.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShooting>().enabled = false;
        }
        if(win)
        {
            win_panel.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerShooting>().enabled = false;
        }
    }

    IEnumerator CountWaves()
    {
        yield return new WaitForSeconds(12f);
        for(int i = 0; i < TotalWave - 1; i++)
        {
            AudioManager.instance.Play(SoundList.RoundStart);
            yield return new WaitForSeconds(30f + enemyNumOnEachWave[i] * 1);
            waves++;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
