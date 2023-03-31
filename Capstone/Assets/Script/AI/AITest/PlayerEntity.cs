using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{

    [SerializeField] Animator animator;
    EntityHealth health;
    GameObject hitPoint;
    public bool isForMelee;
    Melee_Adventure melee = null;
    AdventurePlayer longRange = null;

    void Awake()
    {
        hitPoint = transform.GetChild(0).gameObject;
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<EntityHealth>();
    }
    private void Start()
    {
        if (isForMelee)
        {
            melee = GetComponent<Melee_Adventure>();
        }
        else
            longRange = GetComponent<AdventurePlayer>();
    }
    private void OnEnable()
    {
        EntityHealth.characterIsDead += ResetAnimator;
    }
    private void OnDestroy()
    {
        EntityHealth.characterIsDead -= ResetAnimator;
    }

    void ResetAnimator()
    {
        if (isForMelee)
        {
            melee.enabled = false;
            animator.ResetTrigger("melee");
            animator.SetTrigger("isDead");
            return;
        }
        else
        {
            animator.ResetTrigger("RangeAttack");
            animator.SetTrigger("isDead");
            longRange.enabled = false;
            return;
        }
    }

}
