using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Adventure : MonoBehaviour
{
    [SerializeField] private GameObject weaponCollider;
    PlayerController playerController;
    [SerializeField] private Animator characterAnimation;
    [SerializeField] private WeaponData data;
    public bool isForJunnie;
    public bool isForAzule;
    bool isAttacking = false;
    bool canAttack = true;
    private void Start()
    {
        weaponCollider.SetActive(false);
        characterAnimation = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }



    private void Update()
    {
        if (Input.GetButtonDown("Attack") && canAttack && !isAttacking)
        {
            Debug.Log("Working");
            if (!playerController.isProne)
            {
                isAttacking = true;
                canAttack = false;
                StartCoroutine(AttackDelay());
            }

        }
    }
    IEnumerator AttackDelay()
    {
        characterAnimation.SetTrigger("melee");
        yield return new WaitForSeconds(data.GetItemAttackSpeed(data.itemLevel));
        isAttacking = false;
        canAttack = true;
    }
    public void SwingSound()
    {
        SoundChecker();
    }
    public void CharacterAttack()
    {
        weaponCollider.SetActive(true);
    }
    void SoundChecker()
    {
        if (isForJunnie)
        {
            // somnium.SoundManager.instance.PlaySFX("JunnieAttack");
            somnium.SoundManager.instance.PlaySFX("ShovelSlash");
            return;
        }

        if (isForAzule)
        {
            //somnium.SoundManager.instance.PlaySFX("AzuleAttack");
            somnium.SoundManager.instance.PlaySFX("MeterstickSlash");
            return;
        }

    }
}
