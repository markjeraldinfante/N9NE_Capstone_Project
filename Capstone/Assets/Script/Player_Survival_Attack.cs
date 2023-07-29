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
    public Transform weaponStartpoint;
    public float attackSpeed;
    public string enemyTag = "Enemy"; //The tag of the enemy objects this script could interact with
    private Transform targetEnemy; //The nearest enemy object with the appropriate tag
    private Vector3 directionToTarget; //The direction from the weaponStartpoint to the targetEnemy

    // Start is called before the first frame update
    private void Start()
    {
        characterAnimation = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        targetEnemy = GetNearestEnemy();

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
                    if (targetEnemy != null)
                    {
                        // Set direction towards enemy
                        directionToTarget = (targetEnemy.position - weaponStartpoint.position).normalized;
                        // Set rotation to face opposite direction if player is facing away
                        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget.normalized, Vector3.up);
                        if (Mathf.Abs(Vector3.Dot(directionToTarget.normalized, transform.forward)) < 0.5f)
                        {
                            // Player is facing away from enemy, set bullet direction to player's forward direction
                            directionToTarget = transform.forward;
                            rotationToTarget = Quaternion.LookRotation(directionToTarget.normalized, Vector3.up);
                        }
                        Instantiate(weaponInstantiate, weaponStartpoint.position, rotationToTarget);
                    }
                    else
                    {
                        // No target enemy, set bullet direction to player's forward direction
                        directionToTarget = transform.forward;
                        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget.normalized, Vector3.up);
                        Instantiate(weaponInstantiate, weaponStartpoint.position, rotationToTarget);
                    }
                }
                else
                {
                    //PhotonNetwork.Instantiate(WeaponCollider.name);
                }
            }
        }
    }




    //Returns the nearest enemy object with the appropriate tag
    private Transform GetNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        Transform nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }


}
