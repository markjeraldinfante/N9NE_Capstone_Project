using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float enemyDamage = 5f;
    public float destroyTime = 3f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("char_head") || other.gameObject.CompareTag("char_body") || other.gameObject.CompareTag("char_leftfoot") || other.gameObject.CompareTag("char_rightfoot"))
        {
            EntityHealth entityHealth = other.GetComponentInParent<EntityHealth>();
            if (entityHealth != null)
            {
                entityHealth.TakeDamage(enemyDamage);
                Debug.Log("Damage");
            }
        }
        Destroy(gameObject, destroyTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("char_head") || other.gameObject.CompareTag("char_body") || other.gameObject.CompareTag("char_leftfoot") || other.gameObject.CompareTag("char_rightfoot"))
        {
            somnium.SoundManager.instance.PlaySFX("OmarDamageReceive");
        }

    }
}
