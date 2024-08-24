using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    public GameObject gate1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gate1.SetActive(false);
        Destroy(gameObject);
    }
}
