using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageOverlay : MonoBehaviour
{
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public float duration = 0.5f;

    private bool damaged;

    private void Awake()
    {
        damageImage.enabled = false;
    }

    public void ShowDamage(float damageAmount)
    {
        if (!damaged)
        {
            damaged = true;
            StartCoroutine(ShowDamageOverlay());
        }
    }
    public void Healing(float skillDuration)
    {
        StartCoroutine(ShowHealingOverlay(skillDuration));
    }
    IEnumerator ShowHealingOverlay(float duration)
    {
        damageImage.enabled = true;
        damageImage.color = new Color(0f, 255f, 0f, 0.1f);

        yield return new WaitForSeconds(duration);

        damageImage.enabled = false;
        damaged = false;
    }
    IEnumerator ShowDamageOverlay()
    {
        damageImage.enabled = true;
        damageImage.color = flashColor;

        yield return new WaitForSeconds(duration);

        damageImage.enabled = false;
        damaged = false;
    }
}
