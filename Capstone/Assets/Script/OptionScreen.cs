using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle fullScreenTog;
    public List<ResItems> resolution = new List<ResItems>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;

    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdatedResLabel();

    }
    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolution.Count -1)
        {
            selectedResolution = resolution.Count -1;
        }
        UpdatedResLabel();

    }
    public void UpdatedResLabel()
    {
        resolutionLabel.text = resolution[selectedResolution].horizontal.ToString() + "x" + resolution[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullScreenTog.isOn;
        Screen.SetResolution(resolution[selectedResolution].horizontal,resolution[selectedResolution].vertical, fullScreenTog.isOn);
    }
}
[System.Serializable]
public class ResItems
{  
    public int horizontal, vertical;
}

