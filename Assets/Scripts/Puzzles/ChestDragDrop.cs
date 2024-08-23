using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDragDrop : MonoBehaviour
{
    public GameObject interactUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && interactUI != null)
        {
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && interactUI != null)
        {
            interactUI.SetActive(false);
        }
    }
}
