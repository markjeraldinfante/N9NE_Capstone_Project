using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingobject : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }
     void OnTriggerEnter(Collider col)
{
    if (col.gameObject.tag == "Player")
			rb.isKinematic = false;
}
}
