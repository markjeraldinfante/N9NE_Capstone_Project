using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack_adventure : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.J;
   // [SerializeField] private float attackSpeed = 2f;
    [SerializeField] private Animator characterAnimation;

    
    // Start is called before the first frame update
    private void Start()
    {
        characterAnimation = GetComponent<Animator>();
    }
    // Update is called once per frame
     void Update()
    {

        if (Input.GetKeyDown(attackKey))
        {
            
            characterAnimation.SetTrigger("melee");
        }
        
    }
}
