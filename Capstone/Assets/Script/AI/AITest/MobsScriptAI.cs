using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsScriptAI : MonoBehaviour
{
    private const string playerTag = "Player";
    private GameObject player;
    private Animator animator;
    public float moveSpeed = 2f;
    public float detectionRange = 4f;
    public float minDistance = 1f;
    public enum State { Idle, Attack, Chase };
    public State currentState = State.Idle;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
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
                if (distanceToPlayer <= minDistance)
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
                if (distanceToPlayer > minDistance)
                {
                    currentState = State.Chase;

                }
                break;
        }

        // Set the animator state based on the current state
        //  animator.SetInteger("state", (int)currentState);
    }

    private void Chasing()
    {
        animator.SetBool("chasing", true);
    }
    private void Idling()
    {
        animator.SetBool("chasing", false);
    }
}
