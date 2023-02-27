using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class meleeAttack_adventure : MonoBehaviour
{
    [SerializeField] private baseSurvivalVariant variant;
    [SerializeField] private KeyCode attackKey = KeyCode.J;
    // [SerializeField] private float attackSpeed = 2f;
    [SerializeField] private Animator characterAnimation;
    PhotonView view;

    // Start is called before the first frame update
    private void Start()
    {
        characterAnimation = GetComponent<Animator>();
        if (variant.isOnline)
        {
            view = GetComponent<PhotonView>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            if (variant.isOnline)
            {
                if (view.IsMine)
                {
                    characterAnimation.SetTrigger("melee");
                }
            }
            else
            {
                characterAnimation.SetTrigger("melee");
            }
        }
    }

}
