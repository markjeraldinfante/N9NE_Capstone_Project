using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject levelControls;


    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Collider>().enabled=false;
        thePlayer.GetComponent<EndelessMovement>().enabled=false;
        levelControls.GetComponent<DistanceDisplay>().enabled=false;
        levelControls.GetComponent<EndScoreDisplay>().enabled=true;
        
    }
}
