using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class meleeAttack_adventure : MonoBehaviour
{

    [SerializeField] private KeyCode attackKey = KeyCode.J;
    // [SerializeField] private float attackSpeed = 2f;
    [SerializeField] private Animator characterAnimation;
    PhotonView view;

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
