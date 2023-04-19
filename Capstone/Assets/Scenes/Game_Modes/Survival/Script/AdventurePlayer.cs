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

    [SerializeField] private bool canAttack = true;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] Transform hitpoint;
    public bool isForRico;
    public bool isForOmar;

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

    private IEnumerator Attack()
    {
        SoundChecker();
        characterAnimation.SetTrigger("RangeAttack");
        yield return new WaitForSeconds(0.1f);

        GameObject bato = batoPooler.GetPooledObject(isForRico, 1f);
        if (bato != null)
        {
            bato.transform.position = weaponSpawnPoint.position;
            bato.transform.rotation = transform.rotation;
            bato.SetActive(true);
            Rigidbody batoRigidbody = bato.GetComponent<Rigidbody>();
            batoRigidbody.AddForce(transform.forward * attackSpeed, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        canAttack = true;
    }
}

