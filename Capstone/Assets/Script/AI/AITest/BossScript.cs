using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float movementSpeed = 5f; // The movement speed of the boss enemy
    public float attackRange = 2f; // The range at which the boss enemy can attack the player
    public float attackCooldown = 2f; // The time between each attack
    public float chaseRange = 10f; // The range at which the boss enemy will start chasing the player
    public float maxChaseTime = 10f; // The maximum amount of time the boss enemy will chase the player
    public float attackDamage = 10f; // The amount of damage the boss enemy's attack does
    public float delayBeforeChase = 1f; // The delay before the boss enemy starts chasing the player
    public LayerMask playerLayer; // The layer on which the player is located
    private Animator animator;
    private Transform player; // Reference to the player's transform
    private float lastAttackTime = 0f; // The time at which the boss enemy last attacked the player
    private float currentChaseTime = 0f; // The current amount of time the boss enemy has been chasing the player
    private bool canChase = true; // Whether the boss enemy can start chasing the player

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    private void Update()
    {
        // Calculate the distance between the boss enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the player is within the chase range and the boss enemy has not exceeded the maximum chase time
        if (distanceToPlayer <= chaseRange && currentChaseTime <= maxChaseTime && canChase)
        {
            // Chase the player
            animator.SetTrigger("chase");
            transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);

            // Increase the current chase time
            currentChaseTime += Time.deltaTime;
        }

        // If the player is within attack range and the attack cooldown has passed
        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            // Attack the player
            Attack();

            // Reset the attack cooldown
            lastAttackTime = Time.time;
        }

        // Check if the player has moved away from the boss enemy's chase range
        if (distanceToPlayer > chaseRange)
        {
            // Reset the current chase time
            currentChaseTime = 0f;

            // Delay before the boss enemy can start chasing the player again
            StartCoroutine(DelayBeforeChase());
        }
    }

    private void Attack()
    {
        // Check if the player is in the boss enemy's line of sight
        Vector2 directionToPlayer = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, Mathf.Infinity, playerLayer);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            // Damage the player
            EntityHealth playerHealth = hit.collider.GetComponent<EntityHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }

    private IEnumerator DelayBeforeChase()
    {
        canChase = false;
        yield return new WaitForSeconds(delayBeforeChase);
        canChase = true;
    }
}
