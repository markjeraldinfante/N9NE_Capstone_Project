using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("char_head") || other.gameObject.CompareTag("char_body") || other.gameObject.CompareTag("char_leftfoot") || other.gameObject.CompareTag("char_rightfoot"))
        {
            EntityHealth entityHealth = other.GetComponent<EntityHealth>();
            if (entityHealth != null)
            {
                entityHealth.TakeDamage(20);
                Debug.Log("Damage");
            }
        }

    }
}
