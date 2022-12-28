using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 15f;

    [HideInInspector]
    public float speed;

    public float starthealth = 100;
    private float health;

    public int enemyValue = 75;
    

    [Header("Unity Information")]
    public Image healthBar;
    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        health = starthealth;
    }


    public void DamageTarget(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / starthealth;

        if(health <= 0 && !isDead)
        {   
            Die();
        }
    }

    public void Slow(float value)
    {
        speed = startSpeed * (1f - value);
    }
    
    void Die()
    {
        isDead = true;
        PlayerStats.Money += enemyValue;     
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }


    
}
