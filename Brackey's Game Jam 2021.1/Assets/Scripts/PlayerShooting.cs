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

    private void Start()
    {
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
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
        // Impulse = instant force
        rb.AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void ResetCooldown()
    {
        t = 0;
    }
}
