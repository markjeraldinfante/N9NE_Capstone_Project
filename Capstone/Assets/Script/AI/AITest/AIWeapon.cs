using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EntityHealth entityHealth = other.GetComponent<EntityHealth>();
            if (entityHealth != null)
            {
                entityHealth.TakeDamage(20);
            }
        }
    }
}
