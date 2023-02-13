using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionScreen : MonoBehaviour
{
    public Toggle fullScreenTog;
    public List<ResItems> resolution = new List<ResItems>();
    public int selectedResolution;
    public TMP_Text resolutionLabel;

    private void OnEnable()
    {
        LoadResolution();
        UpdateResolutionLabel();
    }

    public void ResLeft()
    {
        selectedResolution = Mathf.Max(0, selectedResolution - 1);
        UpdateResolutionLabel();
    }

    public void ResRight()
    {
        selectedResolution = Mathf.Min(resolution.Count - 1, selectedResolution + 1);
        UpdateResolutionLabel();
    }

    public void UpdateResolutionLabel()
    {
        resolutionLabel.text = resolution[selectedResolution].horizontal.ToString() + "x" + resolution[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        Screen.SetResolution(resolution[selectedResolution].horizontal, resolution[selectedResolution].vertical, fullScreenTog.isOn);
        SaveResolution();
    }

    public void SaveResolution()
    {
        PlayerPrefs.SetInt("HorizontalRes", resolution[selectedResolution].horizontal);
        PlayerPrefs.SetInt("VerticalRes", resolution[selectedResolution].vertical);

        int toggleValue = fullScreenTog.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Toggle", toggleValue);
    }

    public void LoadResolution()
    {
        if (!PlayerPrefs.HasKey("HorizontalRes") || !PlayerPrefs.HasKey("VerticalRes") || !PlayerPrefs.HasKey("Toggle"))
        {
            PlayerPrefs.SetInt("HorizontalRes", 1920);
            PlayerPrefs.SetInt("VerticalRes", 1080);
            PlayerPrefs.SetInt("Toggle", 1);

            Screen.SetResolution(1920, 1080, true, 120);
        }
        else
        {
            int horizontal = PlayerPrefs.GetInt("HorizontalRes");
            int vertical = PlayerPrefs.GetInt("VerticalRes");
            int toggle = PlayerPrefs.GetInt("Toggle");
            bool isFullscreen = toggle == 1;

            Screen.SetResolution(horizontal, vertical, isFullscreen);
        }
    }
}

[System.Serializable]
public class ResItems
{
    public int horizontal, vertical;
}
