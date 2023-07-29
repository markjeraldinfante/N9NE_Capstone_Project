using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossNameGet : MonoBehaviour
{
    private Transform bossTransform;
    [SerializeField] private TextMeshProUGUI bossName;

    void Start()
    {
        bossTransform = transform.parent;
        bossName.text = bossTransform.name;
    }

}
