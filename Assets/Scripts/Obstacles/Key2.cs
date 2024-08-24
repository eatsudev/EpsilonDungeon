using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2 : MonoBehaviour
{
    public GameObject gate2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gate2.SetActive(false);
        Destroy(gameObject);
    }
}
