using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurvivalAttack : MonoBehaviour
{
    public KeyCode key;
    public Animator animator;
    public GameObject batoObject;
    public Transform point;
    public bool allowFire;

    private void Start()
    {
        allowFire = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(key) && allowFire)
        {

            StartCoroutine(Fire());

        }


        animator.SetBool("Attack", false);
    }

    IEnumerator Fire()
    {
        allowFire = false;
        animator.SetTrigger("attack");
        animator.Play("attack");
        GameObject bato = Instantiate(batoObject, point.position, transform.rotation);
        bato.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
        yield return new WaitForSeconds(.5f);
        allowFire = true;
        Destroy(bato, 2f);
    }
}
