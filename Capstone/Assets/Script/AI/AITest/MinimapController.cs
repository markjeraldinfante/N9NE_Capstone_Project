using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    public Slider miniMapSlider;
    public GameObject startPoint;
    public GameObject endPoint;
    private float levelWidth;
    private Transform playerTransform;
    private void Awake()
    {
        levelWidth = endPoint.transform.position.x - startPoint.transform.position.x;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        float playerXPos = Mathf.Clamp01((playerTransform.position.x - startPoint.transform.position.x) / levelWidth);
        miniMapSlider.value = playerXPos;
    }
    private void Start()
    {

        miniMapSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy()
    {
        miniMapSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void Update()
    {
        float playerXPos = Mathf.Clamp01((playerTransform.position.x - startPoint.transform.position.x) / levelWidth);
        miniMapSlider.value = playerXPos;
    }

    public void OnSliderValueChanged(float value)
    {

        float cameraHeight = Camera.main.orthographicSize * 2.0f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        float xPos = (value * levelWidth) - (cameraWidth / 2.0f);
        float yPos = Camera.main.transform.position.y;

        Vector3 newPosition = Camera.main.transform.position;
        newPosition.x = Mathf.Clamp(xPos, startPoint.transform.position.x + (cameraWidth / 2.0f), endPoint.transform.position.x - (cameraWidth / 2.0f));
        newPosition.y = yPos;

        Camera.main.transform.position = newPosition;
    }
}
