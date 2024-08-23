using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheckHandler : MonoBehaviour
{
    public List<ItemSlot> itemSlots;
    public Animator anim;
    public float delayforAnimation = 1f;
    public GameObject key;
    public GameObject dragDropCanvas;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void CheckItems()
    {
        bool allCorrect = true;

        foreach (ItemSlot slot in itemSlots)
        {
            bool isCorrect = slot.CheckItem();
            if (!isCorrect)
            {
                allCorrect = false;
            }
        }

        if (allCorrect)
        {
            Debug.Log("benar");
            Time.timeScale = 1f;
            dragDropCanvas.SetActive(false);
            StartCoroutine(KeyShowDelay(delayforAnimation));
            anim.SetTrigger("chestOpen");
            StartCoroutine(DestroyAfterDelay(delayforAnimation));
        }
        else
        {
            Debug.Log("salah");
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    private IEnumerator KeyShowDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        key.SetActive(true);
    }
}
