using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float enemyDamage = 5f;
    public float destroyTime = 3f;
    EntityHealth entityHealth;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("char_head") || other.gameObject.CompareTag("char_body") || other.gameObject.CompareTag("char_leftfoot") || other.gameObject.CompareTag("char_rightfoot"))
        {
            entityHealth = other.GetComponentInParent<EntityHealth>();
            if (entityHealth != null)
            {
                if (!entityHealth.IsDead)
                {
                    entityHealth.TakeDamage(enemyDamage);
                    Debug.Log("Damage");
                }
                else
                    Destroy(gameObject);
            }
        }
        Destroy(gameObject, destroyTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("char_head") || other.gameObject.CompareTag("char_body") || other.gameObject.CompareTag("char_leftfoot") || other.gameObject.CompareTag("char_rightfoot"))
        {
            entityHealth = other.GetComponentInParent<EntityHealth>();
            if (!entityHealth.IsDead)
            {
                entityHealth.TakeDamage(enemyDamage);
                Debug.Log("Damage");
                somnium.SoundManager.instance.PlaySFX("OmarDamageReceive");
            }
            else
                Destroy(gameObject);
        }

    }
}
