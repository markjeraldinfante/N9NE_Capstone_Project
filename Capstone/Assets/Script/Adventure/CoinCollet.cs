using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tanso"))
        {

            Destroy(other.gameObject);
        }
    }
}
