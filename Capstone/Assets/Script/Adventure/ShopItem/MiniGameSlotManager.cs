using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class MiniGameSlotManager : MonoBehaviour
{
    public List<MiniGameData> miniGames = new List<MiniGameData>();
    public Transform miniGameContent;
    public GameObject minigameItem;
    public MiniGameSlot minigameSlot;
    private void Start()
    {
        MinigameLists();
    }
    public void MinigameLists()
    {
        foreach (var game in miniGames)
        {
            minigameSlot.minigameData = game;
            minigameSlot.minigameName = game.miniGameName;
            minigameSlot.minigameImage = game.miniGameImage;
            minigameSlot.minigameDescription = game.miniGameDescription;
            minigameSlot.minigameCost = game.miniGameCost;

            GameObject gameObject = Instantiate(minigameItem, miniGameContent);

            var _Name = gameObject.transform.Find("MiniGameName").GetComponent<TextMeshProUGUI>();
            var _Sprite = gameObject.transform.Find("MiniGameImage").GetComponent<Image>();

            _Name.text = minigameSlot.minigameName;
            _Sprite.sprite = minigameSlot.minigameImage;

        }
    }
}
