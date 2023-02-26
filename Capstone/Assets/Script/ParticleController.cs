using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem DustParticle;

    [Range(0,10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0,0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody playerRb;
    float counter;


    private void Update()
    {
        counter += Time.deltaTime;

        if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                Debug.Log("play");
                DustParticle.Play();
                counter = 0;
            }
        }
    }
}
