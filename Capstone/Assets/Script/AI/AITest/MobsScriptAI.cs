using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsScriptAI : MonoBehaviour
{
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
    Rigidbody rb;
    void Start()
    {
        health = GetComponent<EntityHealth>();
        rb = GetComponent<Rigidbody>();
        weaponCollider.enabled = false;
        player = GameObject.FindGameObjectWithTag(playerTag);
        animator = GetComponent<Animator>();
        health.OnDeath += EnemyisDead;
        PlayerEntity.isDead += PlayerisDead;
    }
    private void OnDestroy()
    {
        health.OnDeath -= EnemyisDead;
        PlayerEntity.isDead -= PlayerisDead;
    }
    private void PlayerisDead()
    {
        currentState = State.Idle;
        player = null;
    }
    private void EnemyisDead()
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
                    break;
                }

                if (distanceToPlayer <= attackRange)
                {
                    currentState = State.Attack;
                }
                else if (distanceToPlayer > detectionRange)
                {
                    currentState = State.Idle;
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
                if (distanceToPlayer > attackRange)
                {
                    currentState = State.Chase;
                    Idling(); // stop attacking animation when enemy is chasing
                }
                else
                {
                    Attacking(); // continue attacking animation when enemy is attacking
                }
                break;
        }

        // Set the animator state based on the current state
        // animator.SetInteger("state", (int)currentState);
    }


    private void Chasing()
    {
        weaponCollider.enabled = false;
        animator.SetBool("chasing", true);

        if (rb != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    private void Idling()
    {
        weaponCollider.enabled = false;
        animator.SetBool("chasing", false);
        animator.SetBool("Attack", false);
    }
    private void Attacking()
    {
        animator.SetBool("Attack", true);
        weaponCollider.enabled = true;
    }
}
