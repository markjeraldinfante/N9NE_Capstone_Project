using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private string droneTag = "Drone";
    [SerializeField] private string enemyTag = "enemy";
    [SerializeField] private float enemyDetectionDistance = 5f;
    [SerializeField] private float followSpeed = 3f;
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 1f;
    [SerializeField] private float shootingRange = 5f;
    [SerializeField] private float shootingCooldown = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private float lastShotTime;
    private Transform playerTransform;
    private Vector3 startingPosition;
    private Transform droneModel;
    [SerializeField] private float droneInitialRotationY = 90f;

    private Quaternion droneInitialRotation;
    private bool isFollowingPlayer = false;

    private void Start()
    {
        droneInitialRotation = Quaternion.Euler(0f, droneInitialRotationY, 0f);
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
        startingPosition = transform.position;
        droneModel = GameObject.FindGameObjectWithTag(droneTag).transform;
    }

    private void Update()
    {

        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {

            float distanceToEnemy = Vector3.Distance(transform.position, nearestEnemy.transform.position);
            if (distanceToEnemy <= shootingRange)
            {

                Vector3 direction = nearestEnemy.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                targetRotation.x = 0f;
                targetRotation.z = 0f;
                droneModel.rotation = targetRotation;

                Shoot();


                isFollowingPlayer = false;
            }
            else
            {

                Vector3 direction = nearestEnemy.transform.position - transform.position;
                transform.Translate(direction.normalized * followSpeed * Time.deltaTime);


                isFollowingPlayer = false;
            }
        }
        else
        {
            Vector3 direction = playerTransform.position - transform.position;
            float directionMagnitude = direction.magnitude;

            if (directionMagnitude > 0f && isFollowingPlayer)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                targetRotation.x = 0f;
                targetRotation.z = 0f;
                if (direction.x < 0f)
                {
                    droneModel.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                }
                else if (direction.x > 0f)
                {
                    droneModel.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                }

            }
            else
            {
                droneModel.transform.rotation = Quaternion.Euler(0f, droneModel.transform.rotation.eulerAngles.y, 0f);
            }

            transform.Translate(direction.normalized * followSpeed * Time.deltaTime);


            float y = startingPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            isFollowingPlayer = true;
        }
    }


    private GameObject FindNearestEnemy()
    {
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // GameObject[] EnemyHead = GameObject.FindGameObjectsWithTag("enemyHitpoint");
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
                Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.velocity = direction * 20f;

                // Destroy the bullet after 2 seconds
                Destroy(bullet, 2f);
            }
        }
    }


}
