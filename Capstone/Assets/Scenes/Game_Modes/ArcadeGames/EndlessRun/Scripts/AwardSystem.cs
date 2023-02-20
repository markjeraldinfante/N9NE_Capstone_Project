using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AwardSystem : MonoBehaviour
{
    public int dist;
    public DistanceDisplay distance;
    public GameObject coinCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(distance.disRun >= 100)
        {
            dist = 1;
            coinCount.GetComponent<TextMeshProUGUI>().text= "" + dist;
        }
        if(distance.disRun >= 200)
        {
            dist = 2;
            coinCount.GetComponent<TextMeshProUGUI>().text= "" + dist;
        }
        if(distance.disRun >= 500)
        {
            dist = 3;
            coinCount.GetComponent<TextMeshProUGUI>().text= "" + dist;
        }
        if(distance.disRun >= 1000)
        {
            dist = 4;
            coinCount.GetComponent<TextMeshProUGUI>().text= "" + dist;
        }
        if(distance.disRun >= 2000)
        {
            dist = 5;
            coinCount.GetComponent<TextMeshProUGUI>().text= "" + dist;
        }
        if(distance.disRun >= 4000)
        {
            dist = 6;
            coinCount.GetComponent<TextMeshProUGUI>().text= "" + dist;
        }

    }
        
    

}
