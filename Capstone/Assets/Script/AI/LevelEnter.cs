using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEnter : MonoBehaviour
{
    public LevelBase levelBase;
    public GameObject dialogueBox;
    public GameObject lightCleared = null;
    public TextMeshProUGUI textDialogue;

    public float delay = 0.05f; // Delay between each character of the dialogue
    private int currentLine = 0; // Current line of the dialogue being displayed
    private bool isTyping = false; // Boolean flag to check if the text is currently being typed
    private bool isDialogueDone = false; // Boolean flag to check if the entire dialogue is done


    IEnumerator TypeText()
    {
        foreach (char letter in levelBase.dialogueLines[currentLine].ToCharArray())
        {
            isTyping = true;
            textDialogue.text += letter; // Add the current letter to the dialogue text

            // Check if the current letter is the last letter of the line
            if (letter == levelBase.dialogueLines[currentLine][levelBase.dialogueLines[currentLine].Length - 1])
            {
                // Add a newline character at the end of the line
                textDialogue.text += "\n";
            }

            yield return new WaitForSeconds(delay); // Wait for the specified delay
        }

        isTyping = false;

        // If there are more lines of dialogue, move to the next line
        if (currentLine < levelBase.dialogueLines.Length - 1)
        {
            currentLine++;
            StartCoroutine(TypeText()); // Start typing the next line
        }
        else
        {
            isDialogueDone = true; // Set the dialogue as done
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textDialogue.text = ""; // Clear the dialogue text at the start
            dialogueBox.SetActive(true);
            StartCoroutine(TypeText());
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textDialogue.text = "";
            dialogueBox.SetActive(false);
            Debug.Log("Exit");
        }
    }
}
