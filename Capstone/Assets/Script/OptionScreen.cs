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
    public int selectedResolution;
    public TMP_Text resolutionLabel;


   
    private void OnEnable()
    {
        LoadResolution();




        resolutionLabel.text = PlayerPrefs.GetInt("HorizontalRes").ToString() + "x" + PlayerPrefs.GetInt("VerticalRes").ToString().ToString();
        Debug.Log(resolutionLabel.text);

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
        Screen.SetResolution(resolution[selectedResolution].horizontal,resolution[selectedResolution].vertical, fullScreenTog.isOn, 120);
        SaveResolution();


    }


    public void SaveResolution()
    {
        PlayerPrefs.SetInt("HorizontalRes", resolution[selectedResolution].horizontal);
        PlayerPrefs.SetInt("VerticalRes", resolution[selectedResolution].vertical);

        if (fullScreenTog.isOn==true)
        {
            PlayerPrefs.SetInt("Toggle", 1);
        }
        else
            PlayerPrefs.SetInt("Toggle",0);
    }

    public void LoadResolution()
    {
        //fullScreenTog.isOn = Screen.fullScreen;
        if (!PlayerPrefs.HasKey("HorizontalRes") && !PlayerPrefs.HasKey("VerticalRes") && !PlayerPrefs.HasKey("Toggle"))
        {
            PlayerPrefs.SetInt("HorizontalRes", 1920);
            PlayerPrefs.SetInt("VerticalRes", 1080);
            
            Screen.SetResolution(resolution[PlayerPrefs.GetInt("HorizontalRes")].horizontal, resolution[PlayerPrefs.GetInt("VerticalRes")].vertical, fullScreenTog.isOn=true, 120);
            

        }
        else
        {
            if (PlayerPrefs.GetInt("Toggle") == 1)
            //int HorizontalVal = Convert.ToInt32(PlayerPrefs.GetString("HorizontalRes"));
                Screen.SetResolution(PlayerPrefs.GetInt("HorizontalRes"), PlayerPrefs.GetInt("VerticalRes"), fullScreenTog.isOn =true, 120);

            else
                Screen.SetResolution(PlayerPrefs.GetInt("HorizontalRes"), PlayerPrefs.GetInt("VerticalRes"), fullScreenTog.isOn= false, 120);


        }
       

    }
}
[System.Serializable]
public class ResItems
{  
    public int horizontal, vertical;
}

