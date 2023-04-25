using UnityEngine;

public class AttackObject : MonoBehaviour
{
    public float attackForce = 10f;
    private Collider weaponCol;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Add a BoxCollider component if one doesn't already exist
        weaponCol = GetComponent<Collider>();
        if (weaponCol == null)
        {
            weaponCol = gameObject.AddComponent<CapsuleCollider>();
        }
        rb.AddForce(transform.forward * attackForce, ForceMode.Impulse);
    }



}
