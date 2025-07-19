using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;        
    public float bulletSpeed = 20f;

    public float fireCooldown = 0.5f; // 발사 쿨타임 (0.5초)
    private float lastFireTime = -Mathf.Infinity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastFireTime + fireCooldown)
        {
            Fire();
            lastFireTime = Time.time;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.up * bulletSpeed;
        Destroy(bullet, 3f);
    }
}
