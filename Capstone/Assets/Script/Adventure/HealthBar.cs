using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private TextMeshProUGUI percentageText;
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
    public Slider getSlider()
    {
        return slider;
    }
    public TextMeshProUGUI getPercentageText()
    {
        return percentageText;
    }

}
