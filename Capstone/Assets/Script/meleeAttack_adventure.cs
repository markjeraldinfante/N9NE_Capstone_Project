using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class meleeAttack_adventure : MonoBehaviour
{

    // [SerializeField] private KeyCode attackKey = KeyCode.J;
    // [SerializeField] private float attackSpeed = 2f;
    [SerializeField] private Animator characterAnimation;
    [SerializeField] public basePlayer basePlayer;
    [SerializeField] private baseSurvivalVariant variant;
    PhotonView view;

    // Start is called before the first frame update
    private void Start()
    {
        characterAnimation = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {

        if (!variant.isOnline)
        {
            switch (basePlayer)
            {
                case basePlayer.Player1:
                    if (Input.GetKeyDown(KeyCode.J))
                    {


                        characterAnimation.SetTrigger("melee");

                    }
                    break;
                case basePlayer.Player2:
                    if (Input.GetKeyDown(KeyCode.Keypad0))
                    {


                        characterAnimation.SetTrigger("melee");

                    }
                    break;
            }
        }

    }
}



