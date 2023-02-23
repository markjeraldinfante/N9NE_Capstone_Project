using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField] Animator animator;
    EntityHealth health;
    public GameObject[] hitPoint;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<EntityHealth>();
    }
    void Update()
    {
        if (health.currentHealth < 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        animator.SetTrigger("isDead");
        Destroy(hitPoint[0]);

    }
}
