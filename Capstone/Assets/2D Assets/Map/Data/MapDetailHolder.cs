using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDetailHolder : MonoBehaviour
{
    public MapSO map;
    private Button button;
    public TextMeshProUGUI mapName;
    public MapContextHandler handler;
    public MapContext context;
    [SerializeField] private GameObject loadingScreen = null;
    public int SceneIndex;
    public float doubleClickTimeThreshold = 0.3f; // Maximum time between clicks to count as a double-click
    private float lastClickTime = 0f; // Time of the last click

    void Awake()
    {
        this.button = GetComponent<Button>();
        button.onClick.AddListener(ButtonOnClick);

        if (map.isUnlocked == true) { button.interactable = true; }
        else { button.interactable = false; }
    }

    void ButtonOnClick()
    {
        if (Time.time - lastClickTime < doubleClickTimeThreshold)
        {
            // If the time between clicks is short enough, count it as a double-click
            OnDoubleClick();
            lastClickTime = 0f;
        }
        else
        {
            OnSingleClick();
            // Otherwise, save the time of the click for later comparison
            lastClickTime = Time.time;
        }
    }
    void OnSingleClick()
    {
        mapName.text = map.MapName;
        handler.SetMap(context);
    }

    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneIndex);
    }
    void OnDoubleClick()
    {
        Debug.Log("Double-clicked!");
        handler.SetMap(context);
        StartCoroutine(LoadAsynchronously(SceneIndex));

    }
}

