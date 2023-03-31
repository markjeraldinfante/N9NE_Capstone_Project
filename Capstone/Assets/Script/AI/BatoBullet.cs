using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatoBullet : MonoBehaviour
{
    [SerializeField] private WeaponData slingShot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyHitpoint"))
        {
            EntityHealth entityHealth = other.transform.parent.GetComponent<EntityHealth>();
            BossScript bossScript = other.transform.parent.GetComponent<BossScript>();
            if (bossScript != null) { bossScript.isAttacked = true; }

            if (entityHealth != null)
            {
                entityHealth.TakeDamage(slingShot.GetItemDamage(slingShot.ItemLevel));
            }

            gameObject.SetActive(false); // Deactivate the game object
        }
    }
}

