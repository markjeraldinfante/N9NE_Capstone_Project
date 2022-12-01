using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    Vector3 defaultScale;
    private void Awake()
    {
        defaultScale = gameObject.transform.localScale;

    }
    public void Start()
    {
        LeanTween.reset();
    }

    void PopOutAnimate()
    {
        LeanTween.scale(gameObject, new Vector3(0.9f, 0.9f, 0.9f), 0.1f);
    }

    void PopInAnimate()
    {
        LeanTween.scale(gameObject, defaultScale, 0.1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PopOutAnimate();
        // somnium.SoundManager.instance.PlaySFX("ButtonClick");
        // LeanTween.cancel(gameObject);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PopInAnimate();
        // LeanTween.cancel(gameObject);
    }
}
