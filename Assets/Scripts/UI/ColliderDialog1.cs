using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDialog1 : MonoBehaviour
{
    public GameObject dialog1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialog1.SetActive(true);
        Destroy(gameObject);
    }
}
