using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY1 : MonoBehaviour
{
    private string currentState = "ChaseState";
    private Transform target;

    public float attackRange = 5;
    public float speed = 3;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Base").transform;
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
    }
}
