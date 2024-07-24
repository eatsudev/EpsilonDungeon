using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public int MAX_HEALTH = 100;
    //private bool isDead = false;
    public static PlayerHealth Instance { get; private set; }

    void Start()
    {
        health = MAX_HEALTH;
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void TakeDamage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if(health < 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log("Dead");
    }
}
