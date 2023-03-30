using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
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
    }
    void Update()
    {
        if (health.currentHealth <= 0)
        {
            // Dead();
            health.Die(animator, enemyGameObject);
        }
    }


}
