using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
    public delegate void OnStartAnimation();
    public static event OnStartAnimation onstartAnim;

    void Start()
    {
        StartCoroutine(startAnim(1.5f));
    }
    IEnumerator startAnim(float delay)
    {
        yield return new WaitForSeconds(delay);
        onstartAnim?.Invoke();
    }


}
