using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBombDefuse : MonoBehaviour
{
    public GameObject canvasBombDefuse;
    public GameObject player;
    private PlayerShooting playerShooting;
    private PlayerMovement playerMovement;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player object is not assigned in the Inspector.");
        }
        else
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            playerShooting = player.GetComponentInChildren<PlayerShooting>();

            if (playerMovement == null)
            {
                Debug.LogError("PlayerMovement component not found on the Player object.");
            }
            if (playerShooting == null)
            {
                Debug.LogError("PlayerShooting component not found on the Player object.");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenBombDefuseUI();
        }
    }

    private void OpenBombDefuseUI()
    {
        canvasBombDefuse.SetActive(true);
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
}
