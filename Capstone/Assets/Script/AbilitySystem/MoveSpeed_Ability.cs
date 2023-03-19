using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class MoveSpeed_Ability : Ability
{
    public float movementSpeed;
    public override void Activate(GameObject parent)
    {
        Rigidbody rigidbody = parent.GetComponent<Rigidbody>();
        PlayerController playerController = parent.GetComponent<PlayerController>();

        // playerController.RunSpeed += movementSpeed;

    }
}
