using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public delegate void CharacterIsDead();
    public static event CharacterIsDead isDead;
    [SerializeField] Animator animator;
    EntityHealth health;
    GameObject hitPoint;

    void Awake()
    {
        hitPoint = transform.GetChild(0).gameObject;
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<EntityHealth>();
    }
    void Update()
    {
        if (health.currentHealth <= 0)
        {
            animator.SetTrigger("isDead");
            isDead?.Invoke();
        }
    }

}
