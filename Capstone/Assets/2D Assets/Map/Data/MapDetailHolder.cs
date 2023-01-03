using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MapDetailHolder : MonoBehaviour
{
    public MapSO map;
    private Button button;
    public TextMeshProUGUI mapName;
    void Awake()
    {
        this.button = GetComponent<Button>();
        button.onClick.AddListener(ButtonOnClick);

        if (map.isUnlocked == true) { button.interactable = true; }
        else { button.interactable = false; }
    }
    void ButtonOnClick()
    {
        mapName.text = map.MapName;

    }
}
