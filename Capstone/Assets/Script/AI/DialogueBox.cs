using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public Text dialogueText; // Reference to the UI text object to display the dialogue
    public string[] dialogueLines; // An array of strings that contain the dialogue lines
    public float delay = 0.05f; // Delay between each character of the dialogue

    private int currentLine = 0; // Current line of the dialogue being displayed
    private bool isTyping = false; // Boolean flag to check if the text is currently being typed
    private bool isDialogueDone = false; // Boolean flag to check if the entire dialogue is done

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = ""; // Clear the dialogue text at the start
        StartCoroutine(TypeText()); // Start typing the text
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the dialogue is done and if the player presses any key to close the dialogue
        if (isDialogueDone && Input.anyKeyDown)
        {
            gameObject.SetActive(false); // Hide the dialogue box
        }
    }

    IEnumerator TypeText()
    {
        foreach (char letter in dialogueLines[currentLine].ToCharArray())
        {
            isTyping = true;
            dialogueText.text += letter; // Add the current letter to the dialogue text
            yield return new WaitForSeconds(delay); // Wait for the specified delay
        }
        isTyping = false;

        // If there are more lines of dialogue, move to the next line
        if (currentLine < dialogueLines.Length - 1)
        {
            currentLine++;
            StartCoroutine(TypeText()); // Start typing the next line
        }
        else
        {
            isDialogueDone = true; // Set the dialogue as done
        }
    }
}
