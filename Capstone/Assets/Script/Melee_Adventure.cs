using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Adventure : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.J;
    [SerializeField] private GameObject weaponCollider;

    [SerializeField] private Animator characterAnimation;
    public bool isForJunnie;
    public bool isForAzule;
    private void Start()
    {
        weaponCollider.SetActive(false);
        characterAnimation = GetComponent<Animator>();
    }

    void LateUpdate()
    {

        if (Input.GetKeyDown(attackKey))
        {

            weaponCollider.SetActive(true);
            characterAnimation.SetTrigger("melee");
            SoundChecker();
        }

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
