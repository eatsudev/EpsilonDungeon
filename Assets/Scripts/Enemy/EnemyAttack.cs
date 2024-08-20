using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform[] patrolPoints; 
    private int currentPatrolIndex = 0;
    private bool patrolling = true;

    public Transform player; 
    public float detectionRadius = 5f; 
    public float attackRange = 1.5f; 
    public float attackCooldown = 2f; 
    private bool canAttack = true;
    private bool attacking = false;

    public Animator anim;
    public float moveSpeed = 2f;

    private Vector2 direction;
    public GameObject attackHitbox;

    void Start()
    {
        anim = GetComponent<Animator>();
        patrolling = true;
        attackHitbox.SetActive(false);
    }

    void Update()
    {
        if(player == null)
        {
            return;
        }

        if (attacking) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            patrolling = false;

            if (distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer();
            }
            else
            {
                if (canAttack)
                {
                    StartCoroutine(Attack());
                }
            }
        }
        else if (!patrolling)
        {
            patrolling = true; 
        }

        if (patrolling)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        direction = (targetPatrolPoint.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, targetPatrolPoint.position, moveSpeed * Time.deltaTime);

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", direction.magnitude);

        if (Vector2.Distance(transform.position, targetPatrolPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void MoveTowardsPlayer()
    {
        if (player == null) return;
        direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Speed", direction.magnitude);
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        attacking = true;

        anim.SetTrigger("Attack");
        anim.SetFloat("HorizontalAttack", direction.x);
        anim.SetFloat("VerticalAttack", direction.y);


        attackHitbox.GetComponent<EnemyAttackHitbox>().ResetHitbox();

        yield return new WaitForSeconds(0.5f); 
        attackHitbox.SetActive(true); 

        yield return new WaitForSeconds(0.3f); 
        attackHitbox.SetActive(false); 

        yield return new WaitForSeconds(attackCooldown - 0.6f);

        canAttack = true;
        attacking = false;
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
