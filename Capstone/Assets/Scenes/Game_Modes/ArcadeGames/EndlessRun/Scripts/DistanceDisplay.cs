using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DistanceDisplay : MonoBehaviour
{
    public TextMeshProUGUI disDisplay;
    public TextMeshProUGUI disEndDisplay;
    public int disRun;
    public bool addingDistance = false;

    // Update is called once per frame
    void Update()
    {
        if (addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }
    IEnumerator AddingDistance()
    {
        disRun += 1;
        disDisplay.text = "" + disRun;
        disEndDisplay.text = "" + disRun;
        yield return new WaitForSeconds(0.1f);
        addingDistance = false;
    }
}
