using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Charge_Ability : Ability
{
    public float dashVelocity;
    public override void Activate(GameObject parent)
    {
        PlayerController movement = parent.GetComponent<PlayerController>();
        Rigidbody rigidbody = parent.GetComponent<Rigidbody>();

        if (parent.transform.localScale.x == -1) { rigidbody.AddRelativeForce(Vector3.left * dashVelocity, ForceMode.Impulse); }
        else if (parent.transform.localScale.x == 1) { rigidbody.AddRelativeForce(Vector3.right * dashVelocity, ForceMode.Impulse); }

    }
}
