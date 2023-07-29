using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePlayerDamage : MonoBehaviour
{
    [SerializeField] private WeaponData meleeDamageReference;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyHitpoint"))
        {
            EntityHealth entityHealth = other.transform.parent.GetComponent<EntityHealth>();
            BossScript bossScript = other.transform.parent.GetComponent<BossScript>();
            if (bossScript != null) { bossScript.isAttacked = true; }

            if (entityHealth != null)
            {
                entityHealth.TakeDamage(meleeDamageReference.GetItemDamage(meleeDamageReference.ItemLevel));
                Debug.Log("Damage Enemy");
            }
        }
        if (other.gameObject.CompareTag("Stone"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>(); // Get the Rigidbody component of the baseball
            rb.AddForce(transform.forward * 1000f); // Add a force in the forward direction of the object to make it fly away
        }
    }
}

