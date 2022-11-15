using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 750f;
    public bool allowFire;

    private void Start()
    {
        allowFire = true;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && allowFire)
        {

            StartCoroutine(Fire());

        }

    }

    IEnumerator Fire()
    {
        allowFire = false;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, bulletSpeed, 0));
        yield return new WaitForSeconds(.5f);
        allowFire = true;
        Destroy(bullet, 1f); ;

    }
}
