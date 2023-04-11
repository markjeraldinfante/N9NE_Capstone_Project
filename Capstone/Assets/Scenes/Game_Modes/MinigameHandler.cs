using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameHandler : MonoBehaviour
{
    [SerializeField] private baseMinigame minigame;
    public Button amarraMinigame;
    public Button locoMinigame;
    public Button litexMinigame;
    public Button junkyardMinigame;
    public Button batoPickMinigame;
    void Awake()
    {
        CheckAvailableMinigames();
    }
    private void CheckAvailableMinigames()
    {
        amarraMinigame.gameObject.SetActive(minigame.Amarra);
        locoMinigame.gameObject.SetActive(minigame.Loco);
        litexMinigame.gameObject.SetActive(minigame.Litex);
        junkyardMinigame.gameObject.SetActive(minigame.JunkYard);
        batoPickMinigame.gameObject.SetActive(minigame.BatoPick);
    }

}
