using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;

    private int currentHealth;
    public Animator anim;
    public float delayDead = 1f;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("isDead");
        //StartCoroutine(WaitForAnimationAndDestroy());
        Debug.Log("enemy dead");
        Destroy(gameObject);
    }

    /*private IEnumerator WaitForAnimationAndDestroy()
    {
        
    }*/
}
