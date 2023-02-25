using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Survival_Attack : MonoBehaviour
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

            characterAnimation.SetTrigger("RangeAttack");
        }

    }
}
