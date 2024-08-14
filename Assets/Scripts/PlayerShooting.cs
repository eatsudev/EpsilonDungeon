using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooting : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; 
    private bool canFire = true; 
    private float timer; 
    public float timeBetweenFiring = 0.5f; 

    void Start()
    {
        mainCam = Camera.main; 
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetMouseButton(0) && canFire)
        {
            Shoot();
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector3 bulletDirection = (mousePos - bulletSpawnPoint.position).normalized;

        newBullet.GetComponent<Bullet>().SetDirection(bulletDirection);
        canFire = false;
    }
}
