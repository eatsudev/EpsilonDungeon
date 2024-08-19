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
    public Animator anim;

    void Start()
    {
        mainCam = Camera.main;
        anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        anim.SetFloat("HorizontalAttack", direction.x);
        anim.SetFloat("VerticalAttack", direction.y);

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Shoot(direction);
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

    void Shoot(Vector3 direction)
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().SetDirection(direction);

        anim.SetTrigger("shoot");
        canFire = false;
    }
}
