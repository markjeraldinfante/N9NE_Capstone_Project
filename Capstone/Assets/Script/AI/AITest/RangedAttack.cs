using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;

    public GameObject Bullet;
    public Transform projectileSpawnPoint;
    public float chaseRange = 5;
    public float speed = 3;
    public float attackRange = 1;

    private float shotcooldown;
    public float startshotcooldown;

    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        shotcooldown = startshotcooldown;

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
            animator.SetBool("isAttacking", false);

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
            animator.SetBool("isAttacking", true);
            if (shotcooldown <= 0)
            {
                Instantiate(Bullet, projectileSpawnPoint.position, transform.rotation);
                shotcooldown = startshotcooldown;
            }
            else
            {
                shotcooldown -= Time.deltaTime;
            }

            if (distance > attackRange)
                currentState = "ChaseState";
        }

    }
}
