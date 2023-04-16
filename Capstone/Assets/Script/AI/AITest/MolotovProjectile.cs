using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovProjectile : MonoBehaviour
{
    public GameObject firePrefab;
    public float explosionDelay = 3.0f;
    public float projectileRange;
    private Rigidbody rb;

    public float spinForce = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileRange);

        Vector3 spin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        spin.Normalize();
        spin *= spinForce;
        rb.AddTorque(spin, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            // rb.isKinematic = true;
            Invoke("Explode", explosionDelay);
        }
    }

    private void Explode()
    {
        Instantiate(firePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
