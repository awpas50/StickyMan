using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet;
    public float bulletSpeed;
    public float shootingSpeedPerSecond = 0.25f;
    private float coolDown;
    private float t;

    public SpriteRenderer playerSprite;
    public Color originalColor;
    public Color noBulletColor;


    private bool soundEffectTriggered = false;
    private bool canPlaySound = false;
    private void Start()
    {
        originalColor = playerSprite.color;
        t = 1 / shootingSpeedPerSecond;
    }
    private void Update()
    {
        t += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && t >= 1 / shootingSpeedPerSecond)
        {
            ResetCooldown();
            Shoot();
        }

        if(t >= 1 / shootingSpeedPerSecond)
        {
            playerSprite.color = originalColor;
            
        }
        if (t < 1 / shootingSpeedPerSecond)
        {
            //grey
            playerSprite.color = noBulletColor;
        }
        if(canPlaySound)
        {
            StartCoroutine(PlaySoundAfterDelay());
            canPlaySound = false;
        }
    }

    void Shoot()
    {
        AudioManager.instance.Play(SoundList.PlayerShoot);
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject b = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
        rb.velocity = dir * bulletSpeed;
        b.transform.Rotate(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        // Impulse = instant force
        //rb.AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void ResetCooldown()
    {
        t = 0;
        canPlaySound = true;
    }

    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(7);
        AudioManager.instance.Play(SoundList.Charged);
        StopCoroutine(PlaySoundAfterDelay());
    }
}
