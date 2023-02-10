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
    public bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (!isAttacking)
        {
            TransformEnemy = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed);
            return;
        }
        // else animator.SetBool();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Base")
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);
            Debug.Log("nagcollide");
            return;
        }
    }
}
