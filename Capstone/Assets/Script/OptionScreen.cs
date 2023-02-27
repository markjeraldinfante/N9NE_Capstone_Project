using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionScreen : MonoBehaviour
{
    public defaultSetting defaultSettings;
    public Toggle fullScreenToggle;
    public List<ResolutionItem> resolutions = new List<ResolutionItem>();
    public TMP_Text resolutionLabel;

    public int selectedResolutionIndex;

    private void Awake()
    {

        LoadResolution();
        fullScreenToggle.isOn = defaultSettings.isFullScreen;

    }

    public void ResLeft()
    {
        selectedResolutionIndex = Mathf.Max(0, selectedResolutionIndex - 1);
        UpdateResolutionLabel();
    }

    public void ResRight()
    {
        selectedResolutionIndex = Mathf.Min(resolutions.Count - 1, selectedResolutionIndex + 1);
        UpdateResolutionLabel();
    }

    public void UpdateResolutionLabel()
    {
        var selectedResolution = resolutions[selectedResolutionIndex];
        resolutionLabel.text = $"{selectedResolution.horizontal}x{selectedResolution.vertical}";
    }

    public void ApplyGraphics()
    {
        var selectedResolution = resolutions[selectedResolutionIndex];
        defaultSettings.isFullScreen = fullScreenToggle.isOn;
        defaultSettings.horizontalScreen = selectedResolution.horizontal;
        defaultSettings.verticalScreen = selectedResolution.vertical;
        defaultSettings.selectedIndex = selectedResolutionIndex;
        Screen.SetResolution(defaultSettings.horizontalScreen, defaultSettings.verticalScreen, defaultSettings.isFullScreen);
        SaveResolution();
    }

    public void SaveResolution()
    {
        PlayerPrefs.SetInt("HorizontalRes", defaultSettings.horizontalScreen);
        PlayerPrefs.SetInt("VerticalRes", defaultSettings.verticalScreen);
        PlayerPrefs.SetInt("IsFullScreen", defaultSettings.isFullScreen ? 1 : 0);
        PlayerPrefs.SetInt("Index", selectedResolutionIndex); // save selected index
    }


    public void LoadResolution()
    {
        if (PlayerPrefs.HasKey("HorizontalRes") && PlayerPrefs.HasKey("VerticalRes") && PlayerPrefs.HasKey("IsFullScreen"))
        {
            defaultSettings.horizontalScreen = PlayerPrefs.GetInt("HorizontalRes");
            defaultSettings.verticalScreen = PlayerPrefs.GetInt("VerticalRes");
            defaultSettings.isFullScreen = PlayerPrefs.GetInt("IsFullScreen") == 1;
            selectedResolutionIndex = PlayerPrefs.GetInt("Index");
        }
        else
        {
            defaultSettings.horizontalScreen = 1920;
            defaultSettings.verticalScreen = 1080;
            defaultSettings.isFullScreen = true;
            selectedResolutionIndex = 0;
        }

        // Update resolution label text based on selected index
        var selectedResolution = resolutions[selectedResolutionIndex];
        resolutionLabel.text = $"{selectedResolution.horizontal}x{selectedResolution.vertical}";

        Screen.SetResolution(defaultSettings.horizontalScreen, defaultSettings.verticalScreen, defaultSettings.isFullScreen);
    }



}

[System.Serializable]
public class ResolutionItem
{
    public int horizontal;
    public int vertical;
}


