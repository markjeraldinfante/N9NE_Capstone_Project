using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverFade : MonoBehaviour
{
    [SerializeField] private Button playButton, quitButton;
    [SerializeField] private Image panelImage;
    [SerializeField] private Image button1Image;
    [SerializeField] private Image button2Image;
    [SerializeField] private TextMeshProUGUI gameTextImage;
    [SerializeField] private TextMeshProUGUI button1Text;
    [SerializeField] private TextMeshProUGUI button2Text;

    public float fadeDuration;

    void Start()
    {
        LeanTween.reset();
        playButton.interactable = false;
        quitButton.interactable = false;
        // Set the initial alpha value of all the UI elements to 0
        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0);
        button1Image.color = new Color(button1Image.color.r, button1Image.color.g, button1Image.color.b, 0);
        button2Image.color = new Color(button2Image.color.r, button2Image.color.g, button2Image.color.b, 0);
        gameTextImage.color = new Color(gameTextImage.color.r, gameTextImage.color.g, gameTextImage.color.b, 0);
        button1Text.color = new Color(button1Text.color.r, button1Text.color.g, button1Text.color.b, 0);
        button2Text.color = new Color(button2Text.color.r, button2Text.color.g, button2Text.color.b, 0);

        // Apply the fade-in animation to each UI element using LeanTween
        LeanTween.alpha(panelImage.rectTransform, 1f, fadeDuration).setEase(LeanTweenType.easeInOutSine);
        LeanTween.alpha(button1Image.rectTransform, 1f, fadeDuration).setEase(LeanTweenType.easeInOutSine);
        LeanTween.alpha(button2Image.rectTransform, 1f, fadeDuration).setEase(LeanTweenType.easeInOutSine);

        LeanTween.value(gameTextImage.gameObject, new Color(0f, 0f, 0f, 0f), new Color(1f, 1f, 1f, 1f), fadeDuration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnUpdate((Color value) => gameTextImage.color = value);

        LeanTween.value(button1Text.gameObject, new Color(0f, 0f, 0f, 0f), new Color(1f, 1f, 1f, 1f), fadeDuration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnUpdate((Color value) => button1Text.color = value);

        LeanTween.value(button2Text.gameObject, new Color(0f, 0f, 0f, 0f), new Color(1f, 1f, 1f, 1f), fadeDuration)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnUpdate((Color value) => button2Text.color = value).setOnComplete(isFinishFade);

    }
    void isFinishFade()
    {
        playButton.interactable = true;
        quitButton.interactable = true;
    }
}
