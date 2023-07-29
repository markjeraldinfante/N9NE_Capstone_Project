using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaRandomAttack : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float speed = 2;
    public float attackRange = 1;

    public Animator animator;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //animator = GetComponent<Animator>();


    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "IdleState")
        {
            if (distance < chaseRange)
                currentState = "ChaseState";
        }
        else if (currentState == "ChaseState")
        {
            animator.SetTrigger("chase");


            animator.SetBool("Attack", false);




            if (distance < attackRange)
                currentState = "AttackState";



            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (target.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }


        }
        else if (currentState == "AttackState")
        {
            animator.SetBool("Attack", true);
            animator.SetInteger("AttackIndex", Random.Range(0, 4));

            if (distance > attackRange)
                currentState = "ChaseState";
        }


    }
    IEnumerator Ninja()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("Attack");
        animator.SetInteger("AttackIndex", Random.Range(0, 4));
    }
}
