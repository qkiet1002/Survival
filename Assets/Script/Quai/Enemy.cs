using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    //public float damege1;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damege1)
    {
        currentHealth -= damege1;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Handle enemy death
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
