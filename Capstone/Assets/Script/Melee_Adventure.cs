using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Adventure : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.J;
    [SerializeField] private GameObject weaponCollider;

    [SerializeField] private Animator characterAnimation;
    private void Start()
    {
        weaponCollider.SetActive(false);
        characterAnimation = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(attackKey))
        {
            weaponCollider.SetActive(true);
            characterAnimation.SetTrigger("melee");
        }

    }
}
