using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpAnim : MonoBehaviour
{

    [SerializeField] GameObject optionGO, optionBG, optionPanel, OptionOBJ, optionBackBtn;
    [SerializeField] GameObject MainMenuItem1, MainMenuItem2, MainMenuItem3, MainMenuItem4;
    private void Awake()
    {
        LeanTween.reset();
        MainMenuItem1.SetActive(true);
        MainMenuItem2.SetActive(true);
        MainMenuItem3.SetActive(true);
        MainMenuItem4.SetActive(true);
        optionGO.SetActive(false);

    }
    private void Start()
    {
        MainMenuListener.PopUpANim += Enabler;
        MainMenuListener.PopUpANim += LeanFadeBackGround;
        //   MainMenuListener.CloseAnim += DisEnabler;
        // MainMenuListener.CloseAnim += LeanFadeBackGround;
    }
    private void OnDisable()
    {
        MainMenuListener.PopUpANim -= Enabler;
        MainMenuListener.PopUpANim -= LeanFadeBackGround;
        //  MainMenuListener.CloseAnim -= DisEnabler;
        // MainMenuListener.CloseAnim -= LeanFadeBackGround;
    }

    #region EnablePOP
    public void Enabler()
    {
        MainMenuItem1.SetActive(false);
        MainMenuItem2.SetActive(false);
        MainMenuItem3.SetActive(false);
        MainMenuItem4.SetActive(false);
        optionGO.SetActive(true);

    }
    public void LeanFadeBackGround()
    {

        StartCoroutine(StartPOP());

    }
    IEnumerator StartPOP()
    {
        yield return new WaitForSeconds(1.2f);
        Image r = optionBG.GetComponent<Image>();
        LeanTween.value(optionBG, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(LeanFadePanel);

    }
    public void LeanFadePanel()
    {
        Image r = optionPanel.GetComponent<Image>();
        LeanTween.value(optionPanel, 0, 0.77f, 2f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(POPupOptionobj);

    }
    public void POPupOptionobj()
    {
        LeanTween.scale(OptionOBJ, new Vector3(1f, 1f, 1f), 1.5f).setEaseOutBack().setOnComplete(BackButton);
        // LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.8f).setEaseOutBack();
        // transform.LeanScale(Vector3.one, 0.8f).setEaseOutBack();
        // transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
        // LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.8f).setEaseOutBack();
    }
    public void BackButton()
    {
        Image r = optionBackBtn.GetComponent<Image>();
        LeanTween.value(optionBackBtn, 0, 1, 1.5f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(backButtonText);

    }
    public void backButtonText()
    {
        TextMeshProUGUI r = optionBackBtn.GetComponentInChildren<TextMeshProUGUI>();
        LeanTween.value(optionBackBtn, 0, 1, 0.8f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        });

    }
    #endregion
    /*
        #region DisEnablePOP
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
            yield return new WaitForSeconds(1.2f);

            TextMeshProUGUI r = optionBackBtn.GetComponentInChildren<TextMeshProUGUI>();
            LeanTween.value(optionBackBtn, 1, 0, 0.8f).setOnUpdate((float val) =>
            {
                Color c = r.color;
                c.a = val;
                r.color = c;
            }).setOnComplete(BackButtonOut);


        }
        public void LeanFadeOutPanel()
        {
            Image r = optionPanel.GetComponent<Image>();
            LeanTween.value(optionPanel, 0.77f, 0, 2f).setOnUpdate((float val) =>
            {
                Color c = r.color;
                c.a = val;
                r.color = c;
            }).setOnComplete(backGroundout);

        }
        public void POPoutOptionobj()
        {
            LeanTween.scale(OptionOBJ, new Vector3(0f, 0f, 0f), 1.5f).setEaseOutBack().setOnComplete(LeanFadeOutPanel);
            // LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.8f).setEaseOutBack();
            // transform.LeanScale(Vector3.one, 0.8f).setEaseOutBack();
            // transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
            // LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.8f).setEaseOutBack();
        }
        public void BackButtonOut()
        {
            Image r = optionBackBtn.GetComponent<Image>();
            LeanTween.value(optionBackBtn, 1, 0, 1.5f).setOnUpdate((float val) =>
            {
                Color c = r.color;
                c.a = val;
                r.color = c;
            }).setOnComplete(POPoutOptionobj);

        }
        public void backGroundout()
        {
            Image r = optionBG.GetComponent<Image>();
            LeanTween.value(optionBG, 1, 0, 2).setOnUpdate((float val) =>
            {
                Color c = r.color;
                c.a = val;
                r.color = c;
            }).setOnComplete(DisEnabler);

        }

        #endregion
    */
}
