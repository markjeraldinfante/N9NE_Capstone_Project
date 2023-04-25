using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Minigame", menuName = "Minigames/Minigame")]
public class MiniGameData : ScriptableObject
{
    public string miniGameName;
    public Sprite miniGameImage;
    public string miniGameDescription;
    public int miniGameCost;
    [SerializeField] private bool isBoughtt;

    public bool IsBought { get => isBoughtt; set => isBoughtt = value; }

    public float GetMinigameCost()
    {
        return miniGameCost;
    }
    public void Purchase(System.Action onPurchase = null)
    {
        SavingState.instance.SaveMiniGame(this, true);
        // Call the callback, if it exists
        onPurchase?.Invoke();
    }

}
