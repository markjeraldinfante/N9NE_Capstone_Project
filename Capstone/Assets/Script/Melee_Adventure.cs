using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Adventure : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.J;

    [SerializeField] private Animator characterAnimation;
    private void Start()
    {
        characterAnimation = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(attackKey))
        {

            characterAnimation.SetTrigger("melee");
        }

    }
}
