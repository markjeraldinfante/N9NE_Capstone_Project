using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefListener : MonoBehaviour
{
    private static PlayerPrefListener instance;

    public static PlayerPrefListener Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerPrefListener>();
                if (instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = "PlayerPrefListener";
                    instance = gameObject.AddComponent<PlayerPrefListener>();
                }
            }
            return instance;
        }
    }

    public delegate void PlayerPrefsValueChanged(int newValue);
    public event PlayerPrefsValueChanged OnValueChanged;

    private string key;
    private int previousValue;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartListening(string key)
    {
        this.key = key;
        previousValue = PlayerPrefs.GetInt(key, 0);
    }

    private void Update()
    {
        int currentValue = PlayerPrefs.GetInt(key, 0);
        if (currentValue != previousValue)
        {
            previousValue = currentValue;
            OnValueChanged?.Invoke(currentValue);
        }
    }
}

