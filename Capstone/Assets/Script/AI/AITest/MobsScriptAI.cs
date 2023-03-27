using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsScriptAI : MonoBehaviour
{
    private const string playerTag = "Player";
    private GameObject player;
    public float moveSpeed = 2f;
    public float detectionRange = 4f;
    [SerializeField] Animator animator;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= detectionRange)
        {
            // Move towards the player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            animator.SetTrigger("chase");
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
    }
}
