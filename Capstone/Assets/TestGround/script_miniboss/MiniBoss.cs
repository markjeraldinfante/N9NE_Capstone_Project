using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float speed = 3;
    public float attackRange = 2;

    public Animator animator;

   

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
       

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

            

            if (target.position.x > transform.position.x)
            {
                //move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                //move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
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
    IEnumerator AttackBoss()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Attack");
        animator.SetInteger("AttackIndex", Random.Range(0, 4));
    }

    

}
