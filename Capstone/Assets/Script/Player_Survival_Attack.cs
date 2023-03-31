using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Survival_Attack : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.J;

    private Animator characterAnimation;
    [SerializeField] public basePlayer basePlayer;
    [SerializeField] private baseSurvivalVariant variant;
    PhotonView view;
    public bool isMelee;

    // Start is called before the first frame update
    private void Start()
    {
        characterAnimation = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (variant.variantType != baseSurvivalVariant.VariantType.Online)
        {
            switch (basePlayer)
            {
                case basePlayer.Player1:
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        if (isMelee)
                        {
                            characterAnimation.SetTrigger("melee");
                        }
                        characterAnimation.SetTrigger("RangeAttack");
                    }
                    break;
                case basePlayer.Player2:
                    if (Input.GetKeyDown(KeyCode.Keypad0))
                    {
                        if (isMelee)
                        {
                            characterAnimation.SetTrigger("melee");
                        }
                        characterAnimation.SetTrigger("RangeAttack");
                    }
                    break;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (isMelee)
                {
                    characterAnimation.SetTrigger("melee");
                }
                characterAnimation.SetTrigger("RangeAttack");
            }
        }

    }

}
