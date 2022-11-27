using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharSlot : MonoBehaviour
{
    public Button btn;
    public string _id;
    public CharacterPreview characterPreview;

    private void Start()
    {
        characterPreview = GameObject.Find("Character Preview").GetComponent<CharacterPreview>();
    }

    void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ButtonOnClick);
    }

    void ButtonOnClick()
    {
        characterPreview.DisplayAvatar(_id);
    }
}
