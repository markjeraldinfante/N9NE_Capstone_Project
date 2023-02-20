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

        if (!playerController.isFacingRight)
        {
            rigidbody.AddForce(Vector3.left * dashVelocity, ForceMode.Impulse);
            Debug.Log("negative");
            return;
        }
        else if (playerController.isFacingRight)
        {
            rigidbody.AddForce(Vector3.right * dashVelocity, ForceMode.Impulse);
            Debug.Log("positive");
            return;
        }

    }
}
