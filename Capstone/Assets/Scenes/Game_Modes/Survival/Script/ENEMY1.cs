using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY1 : MonoBehaviour
{
    private string currentState = "ChaseState";
    public Transform target;

    public float attackRange = 5;
    public float speed = 0.05f;
    Rigidbody rb;
    public Animator animator;
    Vector3 TransformEnemy;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TransformEnemy = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        //float distance = transform.position;
        //float distance = Vector3.Normalize(transform.position, target.position, speed);

        /*
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
                if (distance > attackRange)
                {
                    currentState = "ChaseState";
                }
         */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Base")
        {
            animator.SetBool("isAttacking", true);
            Debug.Log("nagcollide");
        }
    }
}
