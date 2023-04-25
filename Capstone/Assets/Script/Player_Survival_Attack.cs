using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Survival_Attack : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey = KeyCode.J;

    private Animator characterAnimation;
    [SerializeField] public basePlayer basePlayer;
    PhotonView view;
    public bool isMelee;
    public Collider WeaponCollider;
    public GameObject weaponInstantiate;

    // Start is called before the first frame update
    private void Start()
    {
        characterAnimation = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (SavingState.instance.survivalVariant.variantType != baseSurvivalVariant.VariantType.Online)
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
        else if (SavingState.instance.survivalVariant.variantType == baseSurvivalVariant.VariantType.Online)
        {
            view = GetComponent<PhotonView>();
            if (view.IsMine)
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

    public void CharacterAttack()
    {
        if (isMelee)
        {
            if (WeaponCollider != null)
            {
                WeaponCollider.enabled = true;
            }
        }
        else
        {
            if (weaponInstantiate != null)
            {
                if (SavingState.instance.survivalVariant.variantType != baseSurvivalVariant.VariantType.Online)
                {
                    Instantiate(WeaponCollider);
                }
                else
                {//  PhotonNetwork.Instantiate(WeaponCollider.name);

                }

            }
        }
    }

}
