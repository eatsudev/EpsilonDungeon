using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    private int damage = 1;
    private bool hasHitPlayer = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!hasHitPlayer && collider.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth health = collider.GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
            hasHitPlayer = true; 
        }
    }

    public void ResetHitbox()
    {
        hasHitPlayer = false;
    }
}
