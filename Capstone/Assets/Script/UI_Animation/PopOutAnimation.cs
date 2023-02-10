using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PopOutAnimation : MonoBehaviour
{
    [SerializeField] GameObject optionGO, optionBG, optionPanel, OptionOBJ, optionBackBtn;
    [SerializeField] GameObject MainMenuItem1, MainMenuItem2, MainMenuItem3;
    private void Awake()
    {
        LeanTween.reset();
        MainMenuItem1.SetActive(true);
        MainMenuItem2.SetActive(true);
        MainMenuItem3.SetActive(true);
        optionGO.SetActive(false);

    }
    private void Start()
    {
        MainMenuListener.CloseAnim += LeanFadeOutBackGround;
        //MainMenuListener.CloseAnim += DisEnabler;

    }
    private void OnDisable()
    {
        MainMenuListener.CloseAnim -= DisEnabler;
        MainMenuListener.CloseAnim -= LeanFadeOutBackGround;
    }


    public void DisEnabler()
    {
        MainMenuItem1.SetActive(true);
        MainMenuItem2.SetActive(true);
        MainMenuItem3.SetActive(true);
        optionGO.SetActive(false);

    }
    public void LeanFadeOutBackGround()
    {

        StartCoroutine(StartPOPout());

    }
    IEnumerator StartPOPout()
    {
        yield return new WaitForSeconds(1f);

        TextMeshProUGUI r = optionBackBtn.GetComponentInChildren<TextMeshProUGUI>();
        LeanTween.value(optionBackBtn, 1, 0, 0.4f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(BackButtonOut);


    }
    public void LeanFadeOutPanel()
    {
        Image r = optionPanel.GetComponent<Image>();
        LeanTween.value(optionPanel, 0.77f, 0, 1.2f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(backGroundout);

    }
    public void POPoutOptionobj()
    {
        LeanTween.scale(OptionOBJ, new Vector3(0f, 0f, 0f), 1f).setEaseOutBack().setOnComplete(LeanFadeOutPanel);
        // LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.8f).setEaseOutBack();
        // transform.LeanScale(Vector3.one, 0.8f).setEaseOutBack();
        // transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
        // LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.8f).setEaseOutBack();
    }
    public void BackButtonOut()
    {
        Image r = optionBackBtn.GetComponent<Image>();
        LeanTween.value(optionBackBtn, 1, 0, 1.2f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(POPoutOptionobj);

    }
    public void backGroundout()
    {
        Image r = optionBG.GetComponent<Image>();
        LeanTween.value(optionBG, 1, 0, 1.2f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(DisEnabler);

    }
}
