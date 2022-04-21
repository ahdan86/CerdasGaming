using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private HealthbarView healthbar;
    //[SerializeField] private Transform targetTransform;
    private float currentHealth;

    List<Tuple<float, float>> respawnEnemy = new List<Tuple<float, float>>{
        new Tuple<float, float>(22, 34),
        new Tuple<float, float>(5, 34),
        new Tuple<float, float>(40, 34),
        new Tuple<float, float>(40, 30),
        new Tuple<float, float>(40, -1),
        new Tuple<float, float>(5, -1),
        new Tuple<float, float>(5, 30),
    };

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bullet")
        {
            currentHealth -= UnityEngine.Random.Range(10f, 15f);
            healthbar.UpdateHealthBar(maxHealth, currentHealth);
        }
        if (other.gameObject.tag == "Player")
        {
            Tuple<float, float> newEnemyPos = respawnEnemy[UnityEngine.Random.Range(0, 6)];
            transform.localPosition = new Vector3(newEnemyPos.Item1, 1.3f, newEnemyPos.Item2);
        }
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
