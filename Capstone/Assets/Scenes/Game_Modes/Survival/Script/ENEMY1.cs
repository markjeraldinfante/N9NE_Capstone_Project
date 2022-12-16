using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY1 : MonoBehaviour
{
    private string currentState = "ChaseState";
    public Transform target;
    
    public float attackRange = 5;
    public float speed = 3;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        

            animator.SetBool("isAttacking", false);

        

        if (currentState == "ChaseState")
        {
            if (distance < attackRange)
                currentState = "AttackState";
        }
        else if (currentState == "AttackState")
        {
            animator.SetBool("isAttacking", true);
        }
        if(distance > attackRange)
        {
            currentState = "ChaseState";
        }
    }
}
