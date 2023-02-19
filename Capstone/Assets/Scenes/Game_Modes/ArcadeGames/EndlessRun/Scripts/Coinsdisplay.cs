using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Coinsdisplay : MonoBehaviour
{
    public GameObject coins;
    public int coinacc;
    public DistanceDisplay distance;
   //public bool addingCoins = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(distance.disRun >= 10)
        {
            coinacc += 1;
            coins.GetComponent<TextMeshProUGUI>().text= "" + coinacc;  
        }    
    }   


}
