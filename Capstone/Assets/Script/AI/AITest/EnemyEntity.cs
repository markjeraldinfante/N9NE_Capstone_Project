using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    public ParticleSystem particles;
    [SerializeField] Animator animator;
    EntityHealth health;
    public GameObject[] hitPoint;
    BossScript bossScript;
    GameObject enemyGameObject;

    void Awake()
    {
        // bossScript = GetComponent<BossScript>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<EntityHealth>();
        enemyGameObject = this.gameObject;
        health.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        health.Die(animator, enemyGameObject, 4f);
        ParticleSystem particleSystem = Instantiate(particles, transform.position, Quaternion.identity);
        particleSystem.Play();
        Debug.Log("Enemy died");
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startLifetime = 1.0f;
    }

}
