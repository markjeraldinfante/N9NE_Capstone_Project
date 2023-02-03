using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadedAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject
    devLogo, gameLogo, backGround, foreGround, panel, versionUI, gameInputs;
    private void Awake()
    {
        LeanTween.reset();
        devLogo.SetActive(false);
        gameLogo.SetActive(false);
    }

    private void Start()
    {
        devLogo.SetActive(true);
        gameLogo.SetActive(true);
        AnimationEventListener.onstartAnim += LeanFadeBackGround;
    }
    public void OnDisable()
    {
        AnimationEventListener.onstartAnim -= LeanFadeBackGround;
    }
    public void LeanFadeBackGround()
    {
        Image r = backGround.GetComponent<Image>();
        LeanTween.value(backGround, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(LeanFadeForeGround);

    }
    public void LeanFadeForeGround()
    {
        Image r = foreGround.GetComponent<Image>();
        LeanTween.value(foreGround, 0, 1, 3).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(LeanFadePanel);

    }
    public void LeanFadePanel()
    {
        Image r = panel.GetComponent<Image>();
        LeanTween.value(panel, 0, 0.77f, 3).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(MoveDevLogo);

    }
    public void MoveDevLogo()
    {
        devLogo.transform.LeanMoveLocal(new Vector3(0, 430, 0), 0.8f).setOnComplete(MoveGameLogo);
        //LeanMoveLocal(new Vector3(0f, -110f, 0f), 0.8f).setEaseOutQuad();
    }
    public void MoveGameLogo()
    {
        gameLogo.transform.LeanMoveLocal(new Vector3(0, 161, 0), 0.8f).setDelay(0.4f).setOnComplete(gameVersion);
    }

    public void InputPop()
    {
        gameInputs.transform.LeanScale(Vector3.one, 0.8f).setEaseOutBack().setDelay(0.6f);
    }
    public void gameVersion()
    {
        TextMeshProUGUI r = versionUI.GetComponent<TextMeshProUGUI>();
        LeanTween.value(versionUI, 0, 1, 3).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(InputPop);
    }
}
