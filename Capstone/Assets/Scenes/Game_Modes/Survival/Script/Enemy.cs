using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MainSpeed;
   // public float turnSpeed;
    
    private string currentState = "ChaseState";
    private Transform target;

    public float attackRange = 5;
    

    public Animator animator;



    public Transform[] CheckPoints;
    int ArrayElementNumber;
    Transform movePoint;

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Base").transform;
        ArrayElementNumber = 0;

        movePoint = CheckPoints[ArrayElementNumber];

    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, MainSpeed * Time.deltaTime);
       
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0)
        {
            ArrayElementNumber++;
            movePoint = CheckPoints[ArrayElementNumber];

        }

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


     /*   IEnumerable<Collider> home = null;
        foreach (Collider homebasee in home)
        {
            Destroy(this.gameObject);
        }*/

        



    }
}
