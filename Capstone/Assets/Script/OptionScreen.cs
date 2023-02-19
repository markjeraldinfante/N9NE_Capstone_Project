using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionScreen : MonoBehaviour
{
    [SerializeField] private defaultSetting setting;
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
        resolution[selectedResolution].horizontal = setting.horizontalScreen;
        resolution[selectedResolution].vertical = setting.verticalScreen;
        fullScreenTog.isOn = setting.isFullScreen;
    }

    public void ApplyGraphics()
    {

        Screen.SetResolution(resolution[selectedResolution].horizontal, resolution[selectedResolution].vertical, fullScreenTog.isOn);
        setting.isFullScreen = fullScreenTog.isOn;
        setting.horizontalScreen = resolution[selectedResolution].horizontal;
        setting.verticalScreen = resolution[selectedResolution].vertical;
        SaveResolution();
    }

    public void SaveResolution()
    {
        PlayerPrefs.SetInt("HorizontalRes", setting.horizontalScreen);
        PlayerPrefs.SetInt("VerticalRes", setting.verticalScreen);

        int toggleValue = setting.isFullScreen ? 1 : 0;
        PlayerPrefs.SetInt("Toggle", toggleValue);

    }

    public void LoadResolution()
    {
        if (!PlayerPrefs.HasKey("HorizontalRes") || !PlayerPrefs.HasKey("VerticalRes") || !PlayerPrefs.HasKey("Toggle"))
        {
            PlayerPrefs.SetInt("HorizontalRes", 1920);
            PlayerPrefs.SetInt("VerticalRes", 1080);
            PlayerPrefs.SetInt("Toggle", 1);
            setting.horizontalScreen = PlayerPrefs.GetInt("HorizontalRes");
            setting.verticalScreen = PlayerPrefs.GetInt("VerticalRes");
            int toggle = PlayerPrefs.GetInt("Toggle");
            setting.isFullScreen = toggle == 1;
            Screen.SetResolution(setting.horizontalScreen, setting.verticalScreen, setting.isFullScreen, 120);
        }
        else
        {
            setting.horizontalScreen = PlayerPrefs.GetInt("HorizontalRes");
            setting.verticalScreen = PlayerPrefs.GetInt("VerticalRes");
            int toggle = PlayerPrefs.GetInt("Toggle");
            setting.isFullScreen = toggle == 1;

            Screen.SetResolution(setting.horizontalScreen, setting.verticalScreen, setting.isFullScreen, 120);
        }
    }
}

[System.Serializable]
public class ResItems
{
    public int horizontal, vertical;
}
