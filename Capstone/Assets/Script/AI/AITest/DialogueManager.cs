using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox, ingameHUD;
    public Sprite imagePortrait;
    public Image imageHolder;
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    private int currentLine = 0;
    public float typingSpeed = 0.02f; // the speed at which characters are displayed

    void Start()
    {
        imageHolder.sprite = imagePortrait;
        dialogueText.text = lines[currentLine];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            dialogueBox.SetActive(true);
            ingameHUD.SetActive(false);
            currentLine = 0;
            StartCoroutine(TypeLine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            dialogueBox.SetActive(false);
            ingameHUD.SetActive(true);
            StopAllCoroutines(); // stop any typing coroutines that might be running
        }
    }

    // Coroutine to gradually display the current line character by character
    IEnumerator TypeLine()
    {
        // Clear the dialogue text before typing
        dialogueText.text = "";

        // Loop through each character in the current line and add it to the dialogue text
        foreach (char c in lines[currentLine])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextLine()
    {
        // If the typing coroutine is still running, stop it and display the full line
        if (dialogueText.text != lines[currentLine])
        {
            StopAllCoroutines();
            dialogueText.text = lines[currentLine];
        }
        else
        {
            // Otherwise, move to the next line and start typing it
            currentLine++;

            if (currentLine < lines.Length)
            {
                StartCoroutine(TypeLine());
            }
            else
            {
                dialogueBox.SetActive(false);
                ingameHUD.SetActive(true);
            }
        }
    }
}
