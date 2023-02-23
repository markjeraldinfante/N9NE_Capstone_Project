using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private const string playerTag = "Player";
    [SerializeField] private const string droneTag = "Drone";
    [SerializeField] private const string enemyTag = "enemy";
    [SerializeField] private float enemyDetectionDistance = 5f;
    [SerializeField] private float followSpeed = 3f;
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private float shootingRange = 5f;
    [SerializeField] private float shootingCooldown = 1f;
    [SerializeField] private GameObject bulletPrefab;

    private float lastShotTime;
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
        // Find the nearest enemy
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            // Check if the nearest enemy is within shooting range
            float distanceToEnemy = Vector3.Distance(transform.position, nearestEnemy.transform.position);
            if (distanceToEnemy <= shootingRange)
            {
                // Rotate the drone to face the enemy
                Vector3 direction = nearestEnemy.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                targetRotation.x = 0f;
                targetRotation.z = 0f;
                droneModel.rotation = targetRotation;

                // Shoot at the enemy
                Shoot();
            }
            else
            {
                // Move towards the nearest enemy
                Vector3 direction = nearestEnemy.transform.position - transform.position;
                transform.Translate(direction.normalized * followSpeed * Time.deltaTime);
            }
        }
        else
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

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        if (enemies.Length == 0)
        {
            return null;
        }

        GameObject nearestEnemy = null;
        float shortestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= enemyDetectionDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
    private void Shoot()
    {
        if (Time.time - lastShotTime > shootingCooldown)
        {
            lastShotTime = Time.time;
            GameObject nearestEnemy = FindNearestEnemy();

            if (nearestEnemy != null)
            {
                // calculate direction from drone to nearest enemy
                Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;

                // instantiate bullet and set its velocity to the direction towards the enemy
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.velocity = direction * 20f;
            }
        }
    }


}
