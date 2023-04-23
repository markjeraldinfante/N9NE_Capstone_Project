using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private GameObject gameHUD;
    [SerializeField] private string[] textDialogueMessage;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI textDialogue;

    [SerializeField] private float delay = 0.05f;
    private int currentLine = 0;
    private bool isTyping = false;
    private bool isDialogueDone = false;
    private Coroutine typingCoroutine;

    private IEnumerator TypeDialogue()
    {
        isTyping = true;
        textDialogue.text = "";
        foreach (char letter in textDialogueMessage[currentLine].ToCharArray())
        {
            textDialogue.text += letter;

            if (textDialogue.text.Length == textDialogueMessage[currentLine].Length)
            {
                textDialogue.text += "\n";
            }

            yield return new WaitForSeconds(delay);
        }

        isTyping = false;

        if (currentLine < textDialogueMessage.Length - 1)
        {
            currentLine++;
            typingCoroutine = StartCoroutine(TypeDialogue());
        }
        else
        {
            isDialogueDone = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            gameHUD.SetActive(false);
            textDialogue.text = "";
            dialogueBox.SetActive(true);

            currentLine = 0;
            isDialogueDone = false;

            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeDialogue());

            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            gameHUD.SetActive(true);
            textDialogue.text = "";
            currentLine = 0;
            isDialogueDone = false;
            dialogueBox.SetActive(false);

            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                isTyping = false;
            }

            Debug.Log("Exit");
        }
    }
}
