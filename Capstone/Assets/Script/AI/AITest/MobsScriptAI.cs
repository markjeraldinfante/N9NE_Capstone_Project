using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsScriptAI : MonoBehaviour
{

    public GameObject healthBar;
    EntityHealth health;
    public Collider weaponCollider;
    private const string playerTag = "Player";
    private GameObject player;
    private Animator animator;
    public float moveSpeed = 2f;
    public float detectionRange = 4f;
    public float attackRange = 1f;
    public enum State { Idle, Attack, Chase };
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

                if (distanceToPlayer <= attackRange)
                {
                    currentState = State.Attack;
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
                    if (player.transform.position.x < transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    }
                }
                break;

            case State.Attack:
                if (player == null)
                {
                    currentState = State.Idle;
                    break;
                }
                if (distanceToPlayer > attackRange)
                {
                    currentState = State.Chase;
                    Idling(); // stop attacking animation when enemy is chasing
                }
                else
                {
                    Attacking(); // continue attacking animation when enemy is attacking
                                 // Attack the player



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
                    rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
                }
            }
        }
    }

    private void Idling()
    {
        weaponCollider.enabled = false;
        animator.SetBool("chasing", false);
        animator.SetBool("Attack", false);
        ShowHealthBar(false);
    }
    private void Attacking()
    {
        animator.SetBool("chasing", false);
        animator.SetBool("Attack", true);
        ShowHealthBar(true);
    }
    public void WeaponEnable()
    {
        weaponCollider.enabled = true;
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
