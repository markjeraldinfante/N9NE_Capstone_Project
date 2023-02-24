using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class omarHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Animator animator;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Dead();



        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pamalo")
        {
            TakeDamage(10);

        }
        if (other.gameObject.tag == "fallobj")
        {
            TakeDamage(50);
            DestroyWithTag("fallobj");
        }
        if (other.gameObject.tag == "wire")
        {
            TakeDamage(3);
        }

    }
    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
    private void Dead()
    {
        animator.SetTrigger("isDead");
        // GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 1.4f);
        this.enabled = false;
        GetComponent<PlayerController>().enabled = false;
    }
}
