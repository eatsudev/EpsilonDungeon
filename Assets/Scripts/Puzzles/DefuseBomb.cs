using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefuseBomb : MonoBehaviour
{
    public GameObject canvas;
    public PlayerHealth playerHealth;
    public GameObject player;
    public string[] correctButtons;  
    private HashSet<string> pressedButtons = new HashSet<string>();
    private PlayerShooting playerShooting;
    private PlayerMovement playerMovement;
    private float delayTime = 1f;
    public Animator anim;
    public GameObject key;
    public GameObject explosion;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerShooting = player.GetComponentInChildren<PlayerShooting>();
    }

    public void OnButtonPress(string buttonValue)
    {
        if (pressedButtons.Contains(buttonValue))
        {
            Explode();
            return;
        }

        if (CheckCorrectButton(buttonValue))
        {
            pressedButtons.Add(buttonValue);

            if (pressedButtons.Count >= correctButtons.Length)
            {
                Safe();
            }
        }
        else
        {
            Explode();
        }
    }

    private bool CheckCorrectButton(string buttonValue)
    {
        return System.Array.Exists(correctButtons, button => button == buttonValue) && !pressedButtons.Contains(buttonValue);
    }

    private void Safe()
    {
        Debug.Log("Bomb defused!");
        playerMovement.enabled = true;
        playerShooting.enabled = true;

        canvas.SetActive(false);
        StartCoroutine(DelayForAnim(delayTime));
        anim.SetTrigger("chestOpen");
        StartCoroutine(KeyShowDelay(delayTime));
    }

    public void Explode()
    {
        Debug.Log("Bomb exploded!");
        canvas.SetActive(false);
        explosion.SetActive(true);
        playerHealth.Die();
    }

    private IEnumerator DelayForAnim(float delay)
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
