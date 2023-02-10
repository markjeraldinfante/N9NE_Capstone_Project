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
    public string CharacterPickingSFX;
    public string characterName;
    public string characterDetails;


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
        characterPreview.DisplayAvatar(_id, characterName, characterDetails);
        somnium.SoundManager.instance.PlaySFX(CharacterPickingSFX);
        //CharacterPickingSFX
    }

}
