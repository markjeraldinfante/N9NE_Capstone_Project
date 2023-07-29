using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePlayer : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    // [SerializeField] private KeyCode attackKey = KeyCode.J;
    [SerializeField] private float attackSpeed = 25f;
    [SerializeField] private ObjectPooler batoPooler;
    [SerializeField] private Transform weaponSpawnPoint;
    [SerializeField] private Animator characterAnimation;
    [SerializeField] private WeaponData data;
    [SerializeField] private bool canAttack = true;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] Transform hitpoint;
    public bool isForRico;
    public bool isForOmar;
    GameObject bato;
    private void Start()
    {


        characterAnimation = GetComponent<Animator>();
        batoPooler = GameObject.FindGameObjectWithTag("ObjPool").GetComponent<ObjectPooler>();
        playerController = GetComponent<PlayerController>();
    }
    void SoundChecker()
    {
        if (isForOmar)
        {
            somnium.SoundManager.instance.PlaySFX("OmarAttack");
            return;
        }

        if (isForRico)
        {
            somnium.SoundManager.instance.PlaySFX("RicoAttack");
            return;
        }

    }
    private void Update()
    {
        if (Input.GetButtonDown("Attack") && canAttack && !isAttacking)
        {
            if (!playerController.isProne)
            {
                isAttacking = true;
                canAttack = false;
                StartCoroutine(Attack());
            }

        }
    }
    public void CharacterAttack()
    {
        SoundChecker();
        bato = batoPooler.GetPooledObject(isForRico, 0.5f);
        if (bato != null)
        {
            bato.transform.position = weaponSpawnPoint.position;
            bato.transform.rotation = weaponSpawnPoint.rotation;
            bato.SetActive(true);
            Rigidbody batoRigidbody = bato.GetComponent<Rigidbody>();
            batoRigidbody.AddForce(transform.forward * attackSpeed, ForceMode.Impulse);

        }


    }

    private IEnumerator Attack()
    {

        characterAnimation.SetTrigger("RangeAttack");
        yield return new WaitForSeconds(data.GetItemAttackSpeed(data.itemLevel));
        isAttacking = false;
        canAttack = true;
    }
}

