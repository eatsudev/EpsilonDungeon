using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialog4 : MonoBehaviour
{
    public GameObject dialog12;
    public GameObject player;
    private PlayerShooting playerShooting;
    private void Awake()
    {
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialog12.SetActive(true);
        playerShooting.enabled = false;
        Destroy(gameObject);
    }
}
