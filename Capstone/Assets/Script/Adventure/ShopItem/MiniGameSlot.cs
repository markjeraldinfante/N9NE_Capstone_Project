using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MiniGameSlot : MonoBehaviour
{
    public MiniGameData minigameData;
    public string minigameName;
    public Sprite minigameImage;
    public string minigameDescription;
    public float minigameCost;

    public Button btn;
    [SerializeField] private MinigamePreview minigamePreview;

    void Awake()
    {
        minigamePreview = GameObject.Find("AdventureManager").GetComponent<MinigamePreview>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ButtonOnClick);
    }

    private void ButtonOnClick()
    {
        minigamePreview.DisplayMinigame(minigameData);

    }
}
