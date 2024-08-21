using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player; 
    public float detectionRadius = 5f; 
    public float attackRange = 1.5f; 
    public float attackCooldown = 2f; 
    private bool canAttack = true;

    public Animator anim;
    public float moveSpeed = 2f;
    public LayerMask playerLayer;

    private Vector2 direction;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(player == null)
        {
            return;
        }


        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {

            if (distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer();
            }
            else
            {
                RaycastForPlayer();
            }
        }
        else
        {
            SetIdle();
        }
        
    }


    void MoveTowardsPlayer()
    {
        if (player == null) return;
        direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        GetComponent<EnemyHealth>().SetLastMovement(direction);

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", direction.magnitude);
    }

    private void RaycastForPlayer()
    {
        if (!canAttack) return;

        Debug.DrawRay(transform.position, direction * attackRange, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, attackRange, playerLayer);

        if (hit.collider != null)
        {

            if (hit.collider.GetComponent<PlayerHealth>() != null)
            {
                StartCoroutine(Attack(hit.collider.GetComponent<PlayerHealth>()));
            }
        }
        
    }

    private IEnumerator Attack(PlayerHealth playerHealth)
    {
        canAttack = false;

        anim.SetTrigger("Attack");
        anim.SetFloat("HorizontalAttack", direction.x);
        anim.SetFloat("VerticalAttack", direction.y);

        yield return new WaitForSeconds(0.5f);

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
        }

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void SetIdle()
    {
        anim.SetFloat("Speed", 0f);
    }

    public void DealDamage()
    {
        Debug.Log("Dealing damage to player");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
