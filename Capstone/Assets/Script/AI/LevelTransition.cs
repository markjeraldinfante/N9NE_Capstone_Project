using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTransition : MonoBehaviour
{
    public GameObject gameHUD;
    public string[] textDialogueMessage;
    public GameObject dialogueBox;
    public TextMeshProUGUI textDialogue;

    public float delay = 0.05f; // Delay between each character of the dialogue
    private int currentLine = 0; // Current line of the dialogue being displayed
    private bool isTyping = false; // Boolean flag to check if the text is currently being typed
    private bool isDialogueDone = false; // Boolean flag to check if the entire dialogue is done
    private Coroutine typingCoroutine; // Reference to the currently running typing coroutine

    IEnumerator TypeText()
    {
        isTyping = true;
        textDialogue.text = "";
        foreach (char letter in textDialogueMessage[currentLine].ToCharArray())

        {
            textDialogue.text += letter; // Add the current letter to the dialogue text

            // Check if the current letter is the last letter of the line
            if (textDialogue.text.Length == textDialogueMessage[currentLine].Length)

            {
                // Add a newline character at the end of the line
                textDialogue.text += "\n";
            }

            yield return new WaitForSeconds(delay); // Wait for the specified delay
        }

        isTyping = false;

        // If there are more lines of dialogue, move to the next line
        if (currentLine < textDialogueMessage.Length - 1)
        {
            currentLine++;
            typingCoroutine = StartCoroutine(TypeText()); // Start typing the next line
        }
        else
        {
            isDialogueDone = true; // Set the dialogue as done
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            gameHUD.SetActive(false);
            textDialogue.text = ""; // Clear the dialogue text at the start
            dialogueBox.SetActive(true);

            currentLine = 0; // Reset the current line
            isDialogueDone = false; // Reset the dialogue done flag

            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine); // Stop any ongoing typing coroutine
            }
            typingCoroutine = StartCoroutine(TypeText()); // Start typing the first line

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
                StopCoroutine(typingCoroutine); // Stop any ongoing typing coroutine
                isTyping = false; // Set isTyping flag to false
            }

            Debug.Log("Exit");
        }
    }
}

