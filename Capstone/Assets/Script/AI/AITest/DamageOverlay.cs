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

    IEnumerator ShowDamageOverlay()
    {
        damageImage.enabled = true;
        damageImage.color = flashColor;

        yield return new WaitForSeconds(duration);

        damageImage.enabled = false;
        damaged = false;
    }
}
