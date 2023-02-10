using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
    public delegate void OnStartAnimation();
    public static event OnStartAnimation onstartAnim;
    public float Delay = 1.5f;

    void Start()
    {
        StartCoroutine(startAnim(Delay));
    }
    IEnumerator startAnim(float delay)
    {
        yield return new WaitForSeconds(delay);
        onstartAnim?.Invoke();
    }


}
