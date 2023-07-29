using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Charge_Ability : Ability
{
    public float dashVelocity;
    public override void Activate(GameObject parent)
    {
        Rigidbody rigidbody = parent.GetComponent<Rigidbody>();
        PlayerController playerController = parent.GetComponent<PlayerController>();

        if (rigidbody != null && playerController != null)
        {

            Vector3 dashDirection = playerController.isFacingRight ? Vector3.right : Vector3.left;
            Vector3 dashForceVector = dashDirection * dashVelocity;
            rigidbody.AddForce(dashForceVector, ForceMode.Impulse);
        }

    }
}
