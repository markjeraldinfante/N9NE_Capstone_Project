using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockPaperScissor : MonoBehaviour
{
    [SerializeField] private MiniGameManager batoPick;
    public GameObject showResultobj;
    public TMP_InputField betField;
    public TextMeshProUGUI matchResult, tansoCount, notice, wonTanso, countDownText;
    public Image displayPlayerChoice, displayEnemyChoiceImage;
    public Sprite[] choicesImage;
    public enum Choice
    { Rock, Paper, Scissors }
    private Choice playerChoice;
    private Choice computerChoice;
    [SerializeField] private Button rockButton;
    [SerializeField] private Button paperButton;
    [SerializeField] private Button scissorButton;
    int betAmount;

    private void Start()
    {
        tansoCount.text = "Total Tanso: " + DBHandler.instance.MainPlayerDB.TansoCount.ToString();
        rockButton.onClick.AddListener(() => CheckBet(Choice.Rock));
        paperButton.onClick.AddListener(() => CheckBet(Choice.Paper));
        scissorButton.onClick.AddListener(() => CheckBet(Choice.Scissors));

    }

    private void CheckBet(Choice choice)
    {
        if (!string.IsNullOrEmpty(betField.text) && int.TryParse(betField.text, out betAmount) && betAmount > 0)
        {
            if (DBHandler.instance.MainPlayerDB.TansoCount >= betAmount)
            {
                PlayGame(choice);
            }
            else
            {
                notice.text = "Not enough tanso";
            }
        }
        else
        {
            notice.text = "You need to bet";
        }
    }

    private void PlayGame(Choice choice)
    {
        notice.text = "";
        playerChoice = choice;
        computerChoice = (Choice)Random.Range(0, 3);
        StartCoroutine(DelayResult());
    }
    IEnumerator DelayResult()
    {
        int count = 5;
        while (count > 0)
        {
            countDownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }
        countDownText.text = ".....";
        yield return new WaitForSeconds(1f);
        showResultobj.SetActive(true);
        ShowImage(playerChoice, computerChoice);
        DetermineWinner();
    }

    private void ShowImage(Choice playerChoice, Choice enemyChoice)
    {
        switch (playerChoice)
        {
            case Choice.Rock:
                displayPlayerChoice.sprite = choicesImage[0];
                break;
            case Choice.Paper:
                displayPlayerChoice.sprite = choicesImage[1];
                break;
            case Choice.Scissors:
                displayPlayerChoice.sprite = choicesImage[2];
                break;
        }

        switch (enemyChoice)
        {
            case Choice.Rock:
                displayEnemyChoiceImage.sprite = choicesImage[0];
                break;
            case Choice.Paper:
                displayEnemyChoiceImage.sprite = choicesImage[1];
                break;
            case Choice.Scissors:
                displayEnemyChoiceImage.sprite = choicesImage[2];
                break;
        }
    }

    private void DetermineWinner()
    {
        if (playerChoice == computerChoice)
        {
            Debug.Log("Tie!");
            wonTanso.text = "";
            Clear();
            matchResult.text = "Tie!";
        }
        else if (playerChoice == Choice.Rock && computerChoice == Choice.Scissors ||
            playerChoice == Choice.Paper && computerChoice == Choice.Rock ||
            playerChoice == Choice.Scissors && computerChoice == Choice.Paper)
        {
            Debug.Log("You win!");
            wonTanso.text = "You won: " + betAmount * 2;
            int winTanso = betAmount + DBHandler.instance.MainPlayerDB.TansoCount;
            DBHandler.instance.UpdateTanso(winTanso);
            Clear();
            matchResult.text = "You win!";
        }
        else
        {
            Debug.Log("Computer wins!");
            int tanso = DBHandler.instance.MainPlayerDB.TansoCount - betAmount;
            wonTanso.text = "You lose: " + betAmount;
            DBHandler.instance.UpdateTanso(tanso);
            Clear();
            matchResult.text = "HAHAHAHA TANGA!";
        }
    }

    private void Clear()
    {
        countDownText.text = "";
        betField.text = "";
        tansoCount.text = "Total Tanso: " + DBHandler.instance.MainPlayerDB.TansoCount.ToString();
    }
}
