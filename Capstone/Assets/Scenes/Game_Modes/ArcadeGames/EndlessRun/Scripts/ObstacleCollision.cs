using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Collider>().enabled=false;
        thePlayer.GetComponent<EndelessMovement>().enabled=false;
        
    }
}
