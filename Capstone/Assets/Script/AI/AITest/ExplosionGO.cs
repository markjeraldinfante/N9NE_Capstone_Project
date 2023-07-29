using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGO : MonoBehaviour
{
    public float delay = 1f;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
