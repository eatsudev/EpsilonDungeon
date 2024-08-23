using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public int MAX_HEALTH = 3;
    public static PlayerHealth Instance { get; private set; }
    public Animator anim;
    private Vector2 lastMovement;
    public float deathDelay = 2f;
    public Transform healthBarFill;

    void Start()
    {
        health = MAX_HEALTH;
        UpdateHealthBar();
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
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
        UpdateHealthBar();

        if (health < 1)
        {
            Die();
        }

    }

    public void SetLastMovement(Vector2 movement)
    {
        lastMovement = movement.normalized;
    }

    public void Die()
    {
        anim.SetBool("isDead", true);

        anim.SetFloat("HorizontalDeath", lastMovement.x);
        anim.SetFloat("VerticalDeath", lastMovement.y);

        StartCoroutine(WaitAndDestroy());
        Debug.Log("Player Dead");
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(deathDelay);

        Destroy(gameObject);
    }

    private void UpdateHealthBar()
    {
        float healthPercent = (float)health / MAX_HEALTH;
        healthBarFill.localScale = new Vector3(healthPercent, 1f, 1f);
    }
}
