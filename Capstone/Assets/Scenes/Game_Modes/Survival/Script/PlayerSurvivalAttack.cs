using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurvivalAttack : MonoBehaviour
{
    public KeyCode key;
    public Animator animator;
    public GameObject batoObject;
    public Transform point;

    void Update()
    {
        if (Input.GetKeyDown(key))
        {

            animator.SetTrigger("attack");
            animator.Play("attack");
            Shoot();
        }


        animator.SetBool("Attack", false);
    }

    void Shoot()
    {
        GameObject bato = Instantiate(batoObject, point.position, transform.rotation);
        bato.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
        Destroy(bato, 2f);
    }
}
