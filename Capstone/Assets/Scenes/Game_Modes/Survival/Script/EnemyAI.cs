using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float MainSpeed;
    public float turnSpeed;

    //   [Space(15)]
    //  public Animator anim;


    public Transform[] CheckPoints;
    int ArrayElementNumber;
    Transform movePoint;

    //   [Space(15)]
    public LayerMask homeLayer;
    //    public float radius;

    void Start()
    {

        ArrayElementNumber = 0;

        movePoint = CheckPoints[ArrayElementNumber];

    }


    void Update()
    {

        //     Collider[] home = Physics.OverlapSphere(transform.position, radius, homeLayer);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, MainSpeed * Time.deltaTime);


        //  Quaternion q = Quaternion.LookRotation(movePoint.position - transform.position);
        //  transform.rotation = Quaternion.RotateTowards(transform.rotation, q, turnSpeed * Time.deltaTime);


        //  anim.SetBool("walk", true);


        if (Vector3.Distance(transform.position, movePoint.position) <= 0)
        {
            ArrayElementNumber++;
            movePoint = CheckPoints[ArrayElementNumber];

        }


        void OnTriggerEnter(Collision other)
        {
            if (other.gameObject.tag == ("Base"))
            {
                Destroy(other.gameObject);
            }
        }



    }

    void OnDrawGizmosSelected()
    {
        //      Gizmos.DrawWireSphere(transform.position, radius);
    }
}
