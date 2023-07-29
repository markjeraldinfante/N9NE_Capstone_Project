using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Heal_Ability : Ability
{
    public int healAmount;
    public float healDuration;

    public override void Activate(GameObject parent)
    {
        Debug.Log("Healing");
        EntityHealth entityHealth = parent.GetComponent<EntityHealth>();
        if (entityHealth != null)
        {
            entityHealth.StartCoroutine(HealOverTime(entityHealth));
        }
    }

    private IEnumerator HealOverTime(EntityHealth entityHealth)
    {
        float timeElapsed = 0f;

        while (timeElapsed < healDuration)
        {
            entityHealth.currentHealth += healAmount * Time.deltaTime;

            if (entityHealth.currentHealth > entityHealth.maxHealth)
            {
                entityHealth.currentHealth = entityHealth.maxHealth;
                break;
            }

            entityHealth.healthBar.SetHealth(entityHealth.currentHealth);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}


