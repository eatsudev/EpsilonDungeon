using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;

    private int currentHealth;
    //public Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
        //anim = GetComponent<Animator>();
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
        //anim.SetTrigger("die");
        //StartCoroutine(WaitForAnimationAndDestroy());
        Debug.Log("enemy dead");
        Destroy(gameObject);
    }
}
