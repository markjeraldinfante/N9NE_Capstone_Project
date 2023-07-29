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
                this.OnEnter?.Invoke();
            }

            currentLine = 0;
            nextButton.SetActive(false);
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
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            if (!this.isDone)
            {
                this.OnEnter?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("char_head"))
        {
            if (!this.isDone)
            {
                this.showDisplay?.Invoke();
                this.OnExit?.Invoke();
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
        this.dialogueText.text = "";

        foreach (char c in lines[currentLine])
        {
            this.dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Line has finished typing, enable next button
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
    }

    public void NextLine()
    {
        nextButton.SetActive(false);

        if (currentLine >= lines.Length)
        {
            return;
        }

        StopAllCoroutines();

        if (dialogueText.text != lines[currentLine])
        {
            this.dialogueText.text = lines[currentLine];
            nextButton.SetActive(true); // Line was not finished typing, enable button again
        }
        else
        {
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
