using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatoBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyHitpoint"))
        {
            EntityHealth entityHealth = other.transform.parent.GetComponent<EntityHealth>();
            if (entityHealth != null)
            {
                entityHealth.TakeDamage(10);
            }
        }
    }
}

