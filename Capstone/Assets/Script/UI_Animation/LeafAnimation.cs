using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafAnimation : MonoBehaviour
{
    public GameObject leaf;
    public float animSpeed;

    void Start()
    {

        LeanTween.moveX(leaf, 40, animSpeed).setEaseInOutQuart().setLoopPingPong();

    }

}
