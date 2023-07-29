using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] private basePlayerSelect playerSelect;
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
            SoundChecker();
            animator.SetTrigger("isDead");
            return;
        }
        else
        {
            animator.ResetTrigger("RangeAttack");
            SoundChecker();
            animator.SetTrigger("isDead");
            longRange.enabled = false;
            return;
        }
    }
    void SoundChecker()
    {
        if (playerSelect.CharacterID == "1")
        {

            somnium.SoundManager.instance.PlaySFX("OmarDeath");
            return;
        }

        if (playerSelect.CharacterID == "2")
        {

            somnium.SoundManager.instance.PlaySFX("JunnieDeath");
            return;
        }
        if (playerSelect.CharacterID == "3")
        {

            somnium.SoundManager.instance.PlaySFX("RicoDeath");
            return;
        }
        if (playerSelect.CharacterID == "4")
        {

            // somnium.SoundManager.instance.PlaySFX("AzuleDeath");
            return;
        }

    }

}
