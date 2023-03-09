using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tanso"))
        {
            somnium.SoundManager.instance.PlaySFX("Coins");
            DBHandler.instance.AddTansoOnCollision();
            Destroy(other.gameObject);
        }
    }
}
