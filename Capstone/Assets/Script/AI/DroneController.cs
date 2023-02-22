using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private const string playerTag = "Player";
    [SerializeField] private const string droneTag = "Drone";
    [SerializeField] private float followSpeed = 3f;
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 1f;

    private Transform playerTransform;
    private Vector3 startingPosition;
    private Transform droneModel;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
        startingPosition = transform.position;
        droneModel = GameObject.FindGameObjectWithTag(droneTag).transform;
    }

    private void Update()
    {
        // Calculate direction to player
        Vector3 direction = playerTransform.position - transform.position;

        // Rotate the drone to face the player, but only if the player is moving
        if (direction.magnitude > 0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            droneModel.rotation = targetRotation;
        }

        // Move towards player
        transform.Translate(direction.normalized * followSpeed * Time.deltaTime);

        // Add sine wave motion
        float y = startingPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}

