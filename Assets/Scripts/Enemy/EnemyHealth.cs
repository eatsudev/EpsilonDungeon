using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    public Animator anim;
    public float delayDead = 1f;
    private Vector2 lastMovement;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(VisualIndicator(Color.red));

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void SetLastMovement(Vector2 movement)
    {
        lastMovement = movement.normalized;
    }

    private void Die()
    {
        anim.SetFloat("HorizontalDeath", lastMovement.x);
        anim.SetFloat("VerticalDeath", lastMovement.y);

        anim.SetTrigger("isDead");

        Debug.Log("enemy dead");

        StartCoroutine(DestroyAfterDelay(delayDead));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
