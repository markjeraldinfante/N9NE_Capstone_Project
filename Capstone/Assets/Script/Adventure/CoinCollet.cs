using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollet : MonoBehaviour
{
    public delegate void OnUpdateTansoText();
    public static event OnUpdateTansoText onUpdateTansoText;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Tanso"))
        {

            somnium.SoundManager.instance.PlaySFX("Coins");
            DBHandler.instance.AddTansoOnCollision();
            onUpdateTansoText?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
