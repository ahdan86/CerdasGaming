using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPPlayer : MonoBehaviour
{
    [SerializeField] private Image healthBarSprite;
    [SerializeField] private float reduceSpeed = 2;
    private float target = 1;
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        target = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
