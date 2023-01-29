using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    Image r;
    [SerializeField] GameObject optionGO, aboutGO;
    private void Awake()
    {
        LeanTween.reset();
    }
    public void Open()
    {
        // LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.8f).setEaseOutBack();
        // transform.LeanScale(Vector3.one, 0.8f).setEaseOutBack();
        optionGO.SetActive(true);
        LeanTween.value(optionGO, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        });
        Debug.Log("pop");
    }
    public void Close()
    {
        LeanTween.value(optionGO, 0, 0, 2).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        });
        optionGO.SetActive(false);
        // transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
        // LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.8f).setEaseOutBack();
    }

}
