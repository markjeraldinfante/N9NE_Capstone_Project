using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public UnityEvent showDisplay, OnEnter, OnExit;
    public GameObject nextButton;
    public GameObject dialogueBox, ingameHUD;
    public Sprite imagePortrait;
    public Image imageHolder;
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    private int currentLine = 0;
    public float typingSpeed = 0.02f; // the speed at which characters are displayed
    public bool isDone;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            if (!this.isDone)
            {
                OnEnter?.Invoke();
            }

            currentLine = 0;
            nextButton.SetActive(true);
            imageHolder.sprite = imagePortrait;

            // Make sure that currentLine is not out of range
            if (currentLine < lines.Length)
            {
                dialogueText.text = lines[currentLine];
                dialogueBox.SetActive(true);
                ingameHUD.SetActive(false);
                StartCoroutine(TypeLine());
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            if (!this.isDone)
            {
                showDisplay?.Invoke();
                OnExit?.Invoke();
            }
            if (this.isDone)
            {
                dialogueBox.SetActive(false);
                ingameHUD.SetActive(true);

            }
            StopAllCoroutines();
            // stop any typing coroutines that might be running
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
    { // stop any typing coroutines that might be running
        if (currentLine >= lines.Length)
        {
            return;
        }
        StopAllCoroutines();
        // If the typing coroutine is still running, stop it and display the full line
        if (dialogueText.text != lines[currentLine])
        {

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
                if (!this.isDone)
                {
                    showDisplay?.Invoke();
                    OnExit?.Invoke();
                }
                isDone = true;
                dialogueBox.SetActive(false);
                ingameHUD.SetActive(true);

            }
        }
    }

}
