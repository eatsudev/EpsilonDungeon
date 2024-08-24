using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key3 : MonoBehaviour
{
    public GameObject gate3;
    public GameObject nextFloorUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gate3.SetActive(false);
        nextFloorUI.SetActive(true);
        Destroy(gameObject);
    }
}
