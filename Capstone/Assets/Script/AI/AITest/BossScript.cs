using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject healthBar;
    public Collider weaponCollider;
    private BossState currentState;
    public float minDistanceToPlayer = 3f; // The minimum distance between the boss and player
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
    private bool isAttacking = false;
    public bool isAttacked = false;
    public bool isBoss;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (!isBoss) { if (healthBar == null) return; }

    }

    private void Start()
    {
        weaponCollider.enabled = false;
        currentState = BossState.Idle;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    private void Update()
    {
        // Calculate the distance between the boss enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if the player is attacking and switch to the chasing state if not already attacking
        if (isAttacked && currentState != BossState.Attacking)
        {
            Debug.Log("isAttacked");
            currentState = BossState.Chasing;
        }

        // Switch between states
        switch (currentState)
        {
            case BossState.Idle:
                // Do nothing until player enters chase range
                if (distanceToPlayer <= chaseRange)
                {
                    currentState = BossState.Chasing;
                }
                break;
            case BossState.Chasing:
                // Move towards player and switch to attack state when within attack range
                if (isBoss) { healthBar.SetActive(true); }
                if (distanceToPlayer > minDistanceToPlayer && distanceToPlayer <= attackRange)
                {
                    currentState = BossState.Attacking;
                }
                else if (distanceToPlayer > minDistanceToPlayer)
                {
                    // Move the boss towards the player
                    animator.SetTrigger("chase");
                    transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
                    if (player.position.x < transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    }
                }
                else
                {
                    // Boss is too close to player, stop its movement
                    GetComponent<Rigidbody>().velocity = Vector2.zero;
                    animator.ResetTrigger("chase");
                }
                break;
            case BossState.Attacking:
                // Attack player and switch back to chase state after a delay
                Attack();
                currentState = BossState.DelayBeforeChase;
                break;
            case BossState.DelayBeforeChase:
                // Wait for a delay before switching back to chase state
                StartCoroutine(DelayBeforeChase());
                break;
        }
    }

    private void Attack()
    {
        canChase = false;
        isAttacking = true;
        Debug.Log("Attacking player!");
        weaponCollider.enabled = true;
        animator.SetBool("Attack", true);
        animator.SetInteger("AttackIndex", Random.Range(0, 4));
        canChase = false;
        // Stop the boss's movement during the attack
        GetComponent<Rigidbody>().velocity = Vector3.zero;
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
        // Call EndAttack() after a delay
        Invoke("EndAttack", 1f);
    }

    private void EndAttack()
    {
        isAttacking = false;
        weaponCollider.enabled = false;
        animator.SetBool("Attack", false);
    }

    private IEnumerator DelayBeforeChase()
    {
        // Wait for a delay before switching back to chase state
        yield return new WaitForSeconds(delayBeforeChase);
        currentState = BossState.Chasing;
    }
}
public enum BossState
{
    Idle,
    Chasing,
    Attacking,
    DelayBeforeChase
}