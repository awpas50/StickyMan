using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Energy")]
    public float energy;
    [SerializeField] private float energyRestoreTime = 1.8f;
    [SerializeField] private float energyRechargeSpeed = 2.5f;
    private float energy_initial;
    private float energyRestoreTimer;
    

    public GameObject firePoint;
    [SerializeField] private GameObject drone1;
    [SerializeField] private GameObject drone2;
    public GameObject bullet;
    public float bulletSpeed;
    public float shootingSpeedPerSecond = 0.25f;
    private float coolDown;
    private float t;

    public SpriteRenderer playerSprite;
    //public Color originalColor;
    //public Color noBulletColor;


    private bool soundEffectTriggered = false;
    private bool canPlaySound = false;
    private void Start()
    {
        //originalColor = playerSprite.color;
        energyRestoreTimer = energyRestoreTime;
        energy_initial = energy;
        t = 1 / shootingSpeedPerSecond;
    }
    private void Update()
    {
        RestoreEnergy();
        t += Time.deltaTime;
        if (Input.GetMouseButton(0) && t >= 1 / shootingSpeedPerSecond && energy >= 1)
        {
            ResetCooldown();
            StartCoroutine(Shoot());
        }

        if(t >= 1 / shootingSpeedPerSecond)
        {
            //playerSprite.color = originalColor;
            
        }
        if (t < 1 / shootingSpeedPerSecond)
        {
            //grey
            //playerSprite.color = noBulletColor;
        }

        //Vector3 dir = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position).normalized;
        //dir = new Vector3(dir.x, dir.y, 0f);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
        mousePosition.x - firePoint.transform.position.x,
        mousePosition.y - firePoint.transform.position.y
        );

        firePoint.transform.up = direction;
    }

    IEnumerator Shoot()
    {
        energyRestoreTimer = 0f;

        Vector3 dir1 = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - drone1.transform.position).normalized;
        dir1 = new Vector3(dir1.x, dir1.y, 0f);

        Vector3 dir2 = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - drone2.transform.position).normalized;
        dir2 = new Vector3(dir2.x, dir2.y, 0f);

        GameObject b1 = Instantiate(bullet, drone1.transform.position, Quaternion.identity);
        Rigidbody2D rb1 = b1.GetComponent<Rigidbody2D>();
        rb1.velocity = dir1.normalized * bulletSpeed;
        b1.transform.Rotate(0, 0, Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg);
        AudioManager.instance.Play(SoundList.PlayerShoot);
        energy -= 0.25f;
        yield return new WaitForSeconds(0.07f);

        GameObject b2 = Instantiate(bullet, drone2.transform.position, Quaternion.identity);
        Rigidbody2D rb2 = b2.GetComponent<Rigidbody2D>();
        rb2.velocity = dir2.normalized * bulletSpeed;
        b2.transform.Rotate(0, 0, Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg);
        AudioManager.instance.Play(SoundList.PlayerShoot);
        energy -= 0.25f;
        yield return new WaitForSeconds(0.07f);

        GameObject b1_1 = Instantiate(bullet, drone1.transform.position, Quaternion.identity);
        Rigidbody2D rb1_1 = b1_1.GetComponent<Rigidbody2D>();
        rb1_1.velocity = dir1.normalized * bulletSpeed;
        b1_1.transform.Rotate(0, 0, Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg);
        AudioManager.instance.Play(SoundList.PlayerShoot);
        energy -= 0.25f;
        yield return new WaitForSeconds(0.07f);

        GameObject b2_1 = Instantiate(bullet, drone2.transform.position, Quaternion.identity);
        Rigidbody2D rb2_1 = b2_1.GetComponent<Rigidbody2D>();
        rb2_1.velocity = dir2.normalized * bulletSpeed;
        b2_1.transform.Rotate(0, 0, Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg);
        AudioManager.instance.Play(SoundList.PlayerShoot);
        energy -= 0.25f;

        //firePoint.transform.Rotate(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        // Impulse = instant force
        //rb.AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void ResetCooldown()
    {
        t = 0;
        //canPlaySound = true;
    }

    //IEnumerator PlaySoundAfterDelay()
    //{
    //    yield return new WaitForSeconds(5.5f);
    //    AudioManager.instance.Play(SoundList.Charged);
    //    StopCoroutine(PlaySoundAfterDelay());
    //}

    void RestoreEnergy()
    {
        energyRestoreTimer += Time.deltaTime;

        if(energy >= energy_initial)
        {
            energy = energy_initial;
        }
        if (energyRestoreTimer >= energyRestoreTime)
        {
            energy += Time.deltaTime * energyRechargeSpeed;
        }
        else
        {
            energy += Time.deltaTime * 0f;
        }
        
    }
    public float GetInitialEnergy()
    {
        return energy_initial;
    }
}
