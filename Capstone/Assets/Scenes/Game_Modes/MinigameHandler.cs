using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameHandler : MonoBehaviour
{
    [SerializeField] private MiniGameData Amarra;
    [SerializeField] private MiniGameData JunkYard;
    [SerializeField] private MiniGameData Litex;
    [SerializeField] private MiniGameData Loco;
    [SerializeField] private MiniGameData BatoPick;

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
        amarraMinigame.gameObject.SetActive(Amarra.IsBought);
        locoMinigame.gameObject.SetActive(Loco.IsBought);
        litexMinigame.gameObject.SetActive(Litex.IsBought);
        junkyardMinigame.gameObject.SetActive(JunkYard.IsBought);
        batoPickMinigame.gameObject.SetActive(BatoPick.IsBought);
    }

}
