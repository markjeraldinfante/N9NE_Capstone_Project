using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurvivalAttack : MonoBehaviour
{
    public KeyCode key;
    Animator animator;
    public GameObject batoObject;
    public Transform point;
    public bool allowFire;



    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
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

    }

    IEnumerator Fire()
    {
        allowFire = false;
        // animator.SetTrigger("attack");
        yield return new WaitForSeconds(.5f);
        GameObject bato = Instantiate(batoObject, point.position, transform.rotation);
        bato.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);

        allowFire = true;
        Destroy(bato, 1f);
    }

}
