using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DulalayScript : MonoBehaviour
{
    public GameObject backFire;
    public GameObject longRangeWeaponPrefab;
    public Transform enemyHand;
    public GameObject healthBar;
    EntityHealth health;
    public Collider weaponCollider;
    private const string playerTag = "Player";
    private GameObject player;
    private Animator animator;
    public float moveSpeed = 2f;
    public float detectionRange = 4f;
    public float meleeRange = 1f;
    public float longRange = 1f;
    public float attackSpeed = 2f; // Attacks per second
    private float attackTimer;
    public enum State { Idle, Chase, LongRangeAttack, MeleeRangeAttack };
    public State currentState = State.Idle;
    public bool isAttacked;
    public bool isBoss = false;
    Rigidbody rb;
    void Start()
    {
        if (!isBoss) { healthBar = null; }
        health = GetComponent<EntityHealth>();
        rb = GetComponent<Rigidbody>();
        weaponCollider.enabled = false;
        player = GameObject.FindGameObjectWithTag(playerTag);
        animator = GetComponent<Animator>();
        health.OnDeath += EnemyisDead;
        EntityHealth.characterIsDead += PlayerisDead;
    }
    private void OnDestroy()
    {
        health.OnDeath -= EnemyisDead;
        EntityHealth.characterIsDead -= PlayerisDead;
    }
    private void EnemyisDead()
    {
        currentState = State.Idle;
        player = null;
    }
    private void PlayerisDead()
    {
        Debug.Log("Player is dead, setting enemy to idle state");
        currentState = State.Idle;
        player = null;
        Debug.Log("Player reference set to null");
    }

    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = 0f;
        if (player != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        }

        if (isAttacked)
        {
            currentState = State.Chase;
        }

        switch (currentState)
        {
            case State.Idle:
                Idling();
                if (distanceToPlayer <= detectionRange)
                {
                    currentState = State.Chase;
                }

                break;
            case State.Chase:
                if (player == null)
                {
                    currentState = State.Idle;
                    isAttacked = false;
                    break;
                }

                if (distanceToPlayer <= meleeRange)
                {
                    currentState = State.MeleeRangeAttack;
                    isAttacked = false;
                }

                else if (distanceToPlayer <= longRange)
                {
                    currentState = State.LongRangeAttack;
                    isAttacked = false;
                }
                else if (distanceToPlayer > detectionRange && !isAttacked)
                {
                    currentState = State.Idle;
                    isAttacked = false;
                    break;
                }
                else
                {
                    // Move towards the player
                    Chasing();
                    Vector3 direction = (player.transform.position - transform.position).normalized;
                    transform.position += direction * moveSpeed * Time.deltaTime;
                    CheckRotation();
                }
                break;
            case State.MeleeRangeAttack:
                if (player == null)
                {
                    currentState = State.Idle;
                    break;
                }
                if (distanceToPlayer > meleeRange)
                {
                    currentState = State.LongRangeAttack;

                }
                else
                {
                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

                    MeleeAttack(distanceToPlayer);// continue attacking animation when enemy is attacking
                                                  // Attack the player
                }
                break;

            case State.LongRangeAttack:
                if (player == null)
                {
                    currentState = State.Idle;
                    break;
                }
                if (distanceToPlayer > longRange)
                {
                    currentState = State.Chase;
                    Idling(); // stop attacking animation when enemy is chasing
                    attackTimer = 0f; // reset attack timer
                }
                else if (distanceToPlayer < meleeRange)
                {
                    currentState = State.MeleeRangeAttack;
                }
                else
                {

                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

                    attackTimer += Time.deltaTime;
                    if (attackTimer >= 1f / attackSpeed)
                    {
                        attackTimer -= 1f / attackSpeed;

                        LongAttacking(); // continue attacking animation when enemy is attacking
                                         // Attack the player
                    }
                }
                break;


        }


    }



    private void Chasing()
    {
        weaponCollider.enabled = false;
        animator.SetBool("chasing", true);
        ShowHealthBar(true);
        if (rb != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Check if the enemy is on the ground
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f))
            {
                if (hit.collider.tag == "ground")
                {
                    // Set the velocity of the rigidbody to move towards the player
                    rb.velocity = direction * moveSpeed;
                }
            }
        }
    }
    private void CheckRotation()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    private void Idling()
    {
        weaponCollider.enabled = false;
        animator.SetBool("chasing", false);
        animator.SetBool("Melee", false);
        animator.SetBool("Range", false);
        ShowHealthBar(false);
    }
    private void MeleeAttacking()
    {

        Debug.Log("MeleeAttacking() called");
        animator.SetBool("chasing", false);
        animator.SetBool("Range", false);
        animator.SetBool("Melee", true);
        animator.SetInteger("MeleeIndex", Random.Range(0, 4));
        weaponCollider.enabled = true;
    }
    private void MeleeAttack(float distance)
    {
        if (distance <= meleeRange)
        {
            // Deal damage to the player
            MeleeAttacking();
        }
    }
    private void LongAttacking()
    {

        animator.SetBool("chasing", false);
        animator.SetBool("Range", true);
        animator.SetInteger("RangeIndex", Random.Range(0, 4));
        ShowHealthBar(true);

    }
    public void WeaponEnable()
    {
        weaponCollider.enabled = true;

    }
    public void Throwing()
    {
        if (backFire != null)
        {
            Invoke("BackFiring", 0.01f);
        }

        Instantiate(longRangeWeaponPrefab, enemyHand.position, transform.rotation);

    }
    public void BackFiring()
    {
        Instantiate(backFire, enemyHand.position, Quaternion.identity);

    }
    public void WeaponDisable()
    {
        weaponCollider.enabled = false;
    }

    private void ShowHealthBar(bool toShow)
    {
        if (toShow)
        {
            if (isBoss)
            {
                healthBar?.SetActive(true);
            }
        }
        else
        {
            if (isBoss)
            {
                healthBar?.SetActive(false);
            }
        }
    }
}
