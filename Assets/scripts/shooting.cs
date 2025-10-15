
using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;
public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;
    public float bulletSpeed = 10f;
    public bool ReadyToFire = true;
    public float firerate = 1f;
    float angleDeg;
    float angleRad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angleRad = angleDeg * Mathf.Deg2Rad;
    }
   
    // Update is called once per framevoid fireCD()

    void Update()
    {
        if (Input.GetMouseButton(0) && ReadyToFire == true)
        {
            Shoot();
            ReadyToFire = false;
            StartCoroutine(FireCoolDown());
        }
   
    }
    void Shoot()
    {
        GameObject bulletPrefab = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        Collider2D col = bulletPrefab.GetComponent<Collider2D>();
        Rigidbody2D rb = bulletPrefab.GetComponent<Rigidbody2D>();
        
        if (col != null)
        {
            col.isTrigger = true;
        }
        if (rb != null)
            {
                UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                UnityEngine.Vector3 direction = mousePos - transform.position;
                angleDeg = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                direction.z = 0;
                direction.Normalize();
                rb.linearVelocity = direction * bulletSpeed;
            }
    }
    IEnumerator FireCoolDown()
    {
        yield return new WaitForSeconds(firerate);
        ReadyToFire = true;
    }
    
}
