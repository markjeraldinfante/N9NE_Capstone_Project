using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Shield_Ability : Ability
{

    public override void Activate(GameObject parent)
    {
        Debug.Log("Shield");

        EntityHealth entityHealth = parent.GetComponent<EntityHealth>();
        if (entityHealth != null)
        {

            entityHealth.isInvulnerable = true;
        }
    }

}
