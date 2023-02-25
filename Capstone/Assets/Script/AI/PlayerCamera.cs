using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

    }
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        virtualCamera.Follow = playerTransform;
    }
}
